using Microsoft.EntityFrameworkCore;
using Statistic.Application.Dto;
using Statistic.Application.Interfaces;
using Statistic.Domain.Models;
using Statistic.Infrastructure.Context;

namespace Statistic.Infrastructure.Repositories
{
    public class MeteorologyRepository : GenericRepository<Meteorology>, IMeteorologyRepository
    {
        private readonly StatisticContext _context;

        public MeteorologyRepository(StatisticContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<MeteorologyDto> Data, int TotalItems)> GetMeteorologyDataAsync(MeteorologyDto filter)
        {
            var query = _context.Meteorologies
                .Include(m => m.Category)
                .Include(m => m.Source)
                .AsQueryable();

            if (filter.Year.HasValue)
                query = query.Where(m => m.Year == filter.Year.Value);

            if (!string.IsNullOrEmpty(filter.Month))
                query = query.Where(m => m.Month == filter.Month);

            if (filter.CategoryId.HasValue)
                query = query.Where(m => m.CategoryId == filter.CategoryId.Value);

            if (filter.SourceId.HasValue)
                query = query.Where(m => m.SourceId == filter.SourceId.Value);

            var totalItems = await query.CountAsync();

            var data = await query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            var mappedData = data.Select(m => new MeteorologyDto
            {
                AirTemperature = m.AirTemperature,
                PrecipitationQuantity = m.PrecipitationQuantity,
                AverageMonthlyWindSpeed = m.AverageMonthlyWindSpeed,
                Month = m.Month,
                Year = m.Year
            });

            return (mappedData, totalItems);
        }
    }
}