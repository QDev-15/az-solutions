using AZ.Infrastructure.Interfaces.IServices;
using GoogleTranslateFreeApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly GoogleTranslator _translator = new GoogleTranslator();

        public async Task<string> TranslateToLanguageAsync(string input, string code = "en")
        {
            var result = await _translator.TranslateLiteAsync(input, Language.Auto, code);
            return result.MergedTranslation;
        }

        // Hàm lưu dữ liệu sau khi dịch
        public async Task SaveTranslatedDataAsync(string originalText, string targetLang)
        {
            var translated = await TranslateTextAsync(originalText, targetLang);

            // TODO: Lưu xuống database hoặc thực hiện hành động tùy ý
            Console.WriteLine($"Translated: {translated}");

            // Ví dụ gọi hàm lưu xuống DB
            // await _repository.SaveAsync(translated);
        }
    }
}
