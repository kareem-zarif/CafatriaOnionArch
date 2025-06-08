using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Domain
{
    public class BranchSupplier : BaseEnt<Guid>
    {
        public DateTime? LastDeal { get; set; } = DateTime.Now;
        public IList<string> HistoryOfDeal { get; set; } = new List<string>();
        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }
        [ForeignKey("Branch")]
        public Guid BranchId { get; set; }
        //nav
        public virtual Supplier Supplier { get; set; }
        public virtual Branch Branch { get; set; }

        //helper method
        public void AddDeal(double amountOfMoney, DateTime timeOfOrder)
        {
            HistoryOfDeal.Add($"{amountOfMoney:C} | {timeOfOrder:MMM-dd:MM:yyyy HH:mm}");
        }
    }
}
