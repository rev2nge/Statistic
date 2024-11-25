using Microsoft.EntityFrameworkCore;
using Statistic.Application.Interfaces;
using Statistic.Domain.Models.Base;
using Statistic.Infrastructure.Context;
using System.Linq.Expressions;

namespace Statistic.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly StatisticContext _context;
        private DbSet<TEntity> DbSet => _context.Set<TEntity>();

        protected GenericRepository(StatisticContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<TEntity>> GetEntitiesAsync()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetEntities() => DbSet.ToList();

        public async Task<TEntity> GetEntityById(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task<List<TProperty>> GetDistinctValuesAsync<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> selector)
        where TEntity : class
        {
            return await _context.Set<TEntity>()
                .Select(selector)
                .Distinct()
                .OrderBy(value => value) 
                .ToListAsync();
        }
    }
}