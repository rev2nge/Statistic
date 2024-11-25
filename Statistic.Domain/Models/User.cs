using Statistic.Domain.Models.Base;

namespace Statistic.Domain.Models
{
    public class User : EntityBaseName
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> Permissions { get; set; }
    }
}