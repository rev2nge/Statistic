using Statistic.Domain.Models;

namespace Statistic.Application.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(int? parentId);
    }
}
