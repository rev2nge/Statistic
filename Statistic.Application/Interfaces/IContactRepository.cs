using Statistic.Domain.Models;

namespace Statistic.Application.Interfaces
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetContact(int? id);
    }
}