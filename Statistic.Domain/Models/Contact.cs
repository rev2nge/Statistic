using Statistic.Domain.Models.Base;

namespace Statistic.Domain.Models
{
    public class Contact : EntityBaseName
    {
        public string? Address { get; set; } 
        public string? Phone { get; set; } 
        public string? Email { get; set; } 
    }
}