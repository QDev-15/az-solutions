using AZ.Infrastructure.Entities;
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
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _repository.AddAsync(category);
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
