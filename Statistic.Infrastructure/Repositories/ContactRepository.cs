using Microsoft.EntityFrameworkCore;
using Statistic.Application.Interfaces;
using Statistic.Domain.Models;
using Statistic.Infrastructure.Context;

namespace Statistic.Infrastructure.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly StatisticContext _context;

        public ContactRepository(StatisticContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContact(int? id)
        {
            return await _context.Contacts.Where(s => s.Id == id.Value).ToListAsync();
        }
    }
}