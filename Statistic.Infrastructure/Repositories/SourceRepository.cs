using Microsoft.EntityFrameworkCore;
using Statistic.Application.Interfaces;
using Statistic.Domain.Models;
using Statistic.Infrastructure.Context;

namespace Statistic.Infrastructure.Repositories
{
    public class SourceRepository : GenericRepository<Source>, ISourceRepository
    {
        private readonly StatisticContext _context;

        public SourceRepository(StatisticContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Source>> GetSource(int? id)
        {
            return await _context.Source.Where(s => s.Id == id.Value).ToListAsync();
        }
    }
}