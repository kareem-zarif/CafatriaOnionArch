using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Domain
{
    public class OrderItem : BaseEnt<Guid>
    {
        public int Quantity { get; set; } = 1;
        public Double UnitPrice { get; set; }
        public string? ItemNotes { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        //nav
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
