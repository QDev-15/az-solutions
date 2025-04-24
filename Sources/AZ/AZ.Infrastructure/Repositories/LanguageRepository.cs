using AZ.Infrastructure.DataAccess;
using AZ.Infrastructure.Entities;
using AZ.Infrastructure.Interfaces.IProviders;
using AZ.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        private readonly ITimeZoneProvider _timeZoneProvider;
        public LanguageRepository(AZDbContext dbContext, ITimeZoneProvider timeZoneProvider) : base(dbContext)
        {
            _timeZoneProvider = timeZoneProvider;
        }
        public async Task<Language> GetByCode(string code)
        {
            var language = await _context.Languages.Where(x => x.IsEnabled).FirstOrDefaultAsync(x => x.Code.ToLower() == code.ToLower());
            return language;
        }

        public async Task<Language> GetDefault()
        {
            var language = await _context.Languages.Where(x => x.IsEnabled).FirstOrDefaultAsync(x => x.IsDefault);
            return language??new Language() { Code = "vi" };
        }

        public async Task<string> GetLanguageCodeDefault()
        {
            var language = await _context.Languages.Where(x => x.IsEnabled).FirstOrDefaultAsync(x => x.Code.ToLower() == _timeZoneProvider.GetLanguageCode().ToLower());
            if (language == null)
            {
                language = await GetDefault();
            }
            return language.Code;
        }

        public async Task<ICollection<string>> GetLanguageCodes()
        {
            var langs = await _context.Languages.Where(x => x.IsEnabled).Select(x => x.Code).ToListAsync();
            return langs;
        }
    }
}
