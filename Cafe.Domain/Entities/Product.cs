using Cafe.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Domain
{
    public class Product : BaseEnt<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public int RemainInStock { get; set; }
        public CategoryEnum Category { get; set; }
        [ForeignKey("Menu")]
        public Guid MenuId { get; set; }
        //nav
        public virtual Menu Menu { get; set; }
        public virtual OrderItem OrderItem { get; set; }
    }
}
