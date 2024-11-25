using Statistic.Domain.Models.Base;
using Statistic.Domain.Models.Enums;

namespace Statistic.Domain.Models
{
    public class Meteorology : EntityBase
    {
        public string AirTemperature { get; set; }
        public string PrecipitationQuantity { get; set; }
        public string AverageMonthlyWindSpeed { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }

        public int? ContactId { get; set; }
        public Contact? Contact { get; set; }

        public MeasurementUnit Unit { get; set; }

        public int SourceId { get; set; }
        public Source Source { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}