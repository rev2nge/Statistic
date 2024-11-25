using Statistic.Domain.Models;
using Statistic.Application.Dto;

namespace Statistic.Application.Interfaces
{
    public interface IMeteorologyRepository : IGenericRepository<Meteorology>
    {
        Task<(IEnumerable<MeteorologyDto> Data, int TotalItems)> GetMeteorologyDataAsync(MeteorologyDto filter);
    }
}