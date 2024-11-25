using Statistic.Domain.Models.Base;

namespace Statistic.Domain.Models
{
    public class Category : EntityBaseName
    {
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
    }
}