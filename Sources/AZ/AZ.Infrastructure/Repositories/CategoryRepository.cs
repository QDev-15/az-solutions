using AZ.Infrastructure.DataAccess;
using AZ.Infrastructure.Entities;
using AZ.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AZDbContext context) : base(context)
        {
        }
        public async Task<Category> GetById(int id)
        {
            return await _context.Categories
                .Include(x => x.CategoryTranslations)
                .Include(x => x.CategoryPermissions)
                .Include(x => x.ParentCategory)
                .Include(x => x.SubCategories)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
