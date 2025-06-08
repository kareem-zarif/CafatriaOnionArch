using Cafe.Domain.Shared;

namespace Cafe.Domain
{
    public class Table : BaseEnt<Guid>
    {
        public string TableName { get; set; }
        public byte Capacity { get; set; }
        public TableStatusEnum TableStatus { get; set; } = TableStatusEnum.Available;
        //nav
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
