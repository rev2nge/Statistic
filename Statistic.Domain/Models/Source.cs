using Statistic.Domain.Models.Base;

namespace Statistic.Domain.Models
{
    public class Source : EntityBaseName
    { 
        public string? Description { get; set; } 
        public string? Link { get; set; }
    }
}