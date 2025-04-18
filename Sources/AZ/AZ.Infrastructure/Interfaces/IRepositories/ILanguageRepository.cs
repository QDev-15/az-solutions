using AZ.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IRepositories
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Task<string> GetLanguageCodeDefault();
        Task<Language> GetDefault();
        Task<Language> GetByCode(string code);
    }
}
