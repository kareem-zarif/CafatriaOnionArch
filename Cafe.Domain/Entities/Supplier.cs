using System.ComponentModel.DataAnnotations;

namespace Cafe.Domain
{
    public class Supplier : BaseEnt<Guid>
    {
        public string Name { get; set; }
        [Required, MinLength(11), MaxLength(13), Phone, RegularExpression(@"^(010|011|012|15)\d{8,10}$", ErrorMessage = "Phone number must start with 010, 011, or 012 and be between 11 and 13 digits")]
        public string phone { get; set; }
        [Required, MinLength(11), MaxLength(13), Phone, RegularExpression(@"", ErrorMessage = "")] public string? Email { get; set; }
        public string? Address { get; set; }
        //nav
        public virtual ICollection<BranchSupplier> BranchSuppliers { get; set; } = new HashSet<BranchSupplier>();
    }
}
