namespace Statistic.Application.Dto
{
    public class MeteorologyDto
    {
        public string? AirTemperature { get; set; }
        public string? PrecipitationQuantity { get; set; }
        public string? AverageMonthlyWindSpeed { get; set; }
        public int? Year { get; set; }
        public string? Month { get; set; }
        public int? CategoryId { get; set; }
        public int? SourceId { get; set; }
        public int Page { get; set; } = 1; 
        public int PageSize { get; set; } = 10; 
    }
}