using Cafe.Domain.Shared;

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
        public virtual ICollection<Menu> Menus { get; set; } = new HashSet<Menu>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
