using Statistic.Domain.Models;

namespace Statistic.Application.Interfaces
{
    public interface ISourceRepository : IGenericRepository<Source>
    {
        Task<IEnumerable<Source>> GetSource(int? id);
    }
}