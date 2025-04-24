using AZ.Core.DTOs.Categories;
using AZ.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<DTO_Category>> GetAllCategoriesAsync();
        Task<DTO_Category> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(DTO_Category category);
        Task UpdateCategoryAsync(DTO_Category category);
        Task DeleteCategoryAsync(int id);
    }
}
