using Cafe.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Cafe.Domain
{
    public class Branch : BaseEnt<Guid>
    {
        //Guid better for
        //1-scurity :: hard to guess
        //2-compact with distrubuted syetems and microservoces
        //3-Data Migration :: Easier to merge databases without conflcits 
        public BranchLocationEnum Location { get; set; } = BranchLocationEnum.Zagazig;
        public string ManagerName { get; set; }
        public TimeOnly OpenAt { get; set; } = new TimeOnly(9, 0);
        public TimeOnly CloseAt { get; set; } = new TimeOnly(14, 30);
        [Required, MinLength(11), MaxLength(13), Phone]
        [RegularExpression(@"^(010|011|012|15)\d{8,10}$", ErrorMessage = "Phone number must start with 010, 011, or 012 and be between 11 and 13 digits")]
        public string Phone { get; set; }
        public string Address { get; set; }
        //nav
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        public virtual ICollection<BranchSupplier> BranchSuppliers { get; set; } = new HashSet<BranchSupplier>();
    }
}
