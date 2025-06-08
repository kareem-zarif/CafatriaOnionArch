using Cafe.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Domain
{
    public class Order : BaseEnt<Guid>
    {
        public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.Pending;
        public double TotalMoney { get; set; }
        public DateTime OrderedOn { get; set; } = DateTime.Now;
        [ForeignKey("Table")]
        public Guid TableId { get; set; }
        //nav
        public virtual Table Table { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
