using Microsoft.EntityFrameworkCore;
using Statistic.Application.Interfaces;
using Statistic.Domain.Models;
using Statistic.Infrastructure.Context;

namespace Statistic.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly StatisticContext _context;

        public CategoryRepository(StatisticContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(int? parentId = null)
        {
            return parentId.HasValue
                ? await _context.Categories.Where(c => c.ParentCategoryId == parentId.Value).ToListAsync()
                : await _context.Categories.Where(c => c.ParentCategoryId == null).ToListAsync();
        }
    }
}