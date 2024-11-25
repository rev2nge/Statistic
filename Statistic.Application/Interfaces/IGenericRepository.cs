using System.Linq.Expressions;

namespace Statistic.Application.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> GetEntities();
        Task<IEnumerable<TEntity>> GetEntitiesAsync();
        Task<TEntity> GetEntityById(int id);
        Task<List<TProperty>> GetDistinctValuesAsync<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> selector) where TEntity : class;
    }
}