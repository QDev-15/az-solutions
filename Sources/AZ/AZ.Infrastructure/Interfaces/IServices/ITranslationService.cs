using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IServices
{
    public interface ITranslationService
    {
        Task<string> TranslateToLanguageAsync(string text, string code);
    }
}
