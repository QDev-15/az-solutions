using AZ.Core.DTOs.Categories;
using AZ.Infrastructure.Entities;
using AZ.Infrastructure.Extentions;
using AZ.Infrastructure.Interfaces.IProviders;
using AZ.Infrastructure.Interfaces.IRepositories;
using AZ.Infrastructure.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _category;
        private readonly IMappingProvider _mappingProvider;
        private readonly ILogQueueProvider _logQueueProvider;
        private string languageCode = "vi";

        public CategoryService(ICategoryRepository category, ILogQueueProvider logQueueProvider, IMappingProvider mappingProvider)
        {
            _logQueueProvider = logQueueProvider; 
            _mappingProvider = mappingProvider;
            _category = category;
            languageCode = _mappingProvider.GetLanguageCode().Result;
        }

        public async Task<IEnumerable<DTO_Category>> GetAllCategoriesAsync()
        {
            var categories = await _category.GetAllAsync();
            return categories.Select(x => _mappingProvider.ReturnCategoryModel(x)).ToList();
        }

        public async Task<DTO_Category> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _category.GetById(id);
                if (category == null)
                {
                    return null;
                }
                return _mappingProvider.ReturnCategoryModel(category);
            } catch(Exception ex)
            {
                _logQueueProvider.LogError(ex.Message, ex.Source, ex.StackTrace);
                return null;
            }
        }

        public async Task<DTO_Category> CreateCategoryAsync(DTO_Category category)
        {
            try
            {
                var langCodes = await _mappingProvider.GetLanguageCodes();
                var cat = new Category()
                {
                    Name = category.Name,
                    
                }
            } catch(Exception e)
            {
                _logQueueProvider.LogError(e.Message, e.Source, e.StackTrace);
                return null;
            }
            await _category.AddAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _repository.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category != null)
            {
                await _repository.DeleteAsync(category);
            }
        }
    }

}
