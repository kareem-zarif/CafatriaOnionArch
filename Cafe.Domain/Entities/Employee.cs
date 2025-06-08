using Cafe.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Domain
{
    public class Employee : BaseEnt<Guid>
    {
        public string Name { get; set; }
        [Required, MinLength(11), MaxLength(13), Phone, RegularExpression(@"", ErrorMessage = "")]
        public string Phone { get; set; }
        [Required, MaxLength(50), EmailAddress, RegularExpression(@"^(010|011|012|15)\d{8,10}$", ErrorMessage = "Phone number must start with 010, 011, or 012 and be between 11 and 13 digits")]
        public string Email { get; set; }
        public EmpRole Role { get; set; } = EmpRole.ServiceEmp;
        public bool IsActive { get; set; }
        public DateOnly? HireDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [ForeignKey("Branch")]
        public Guid BranchId { get; set; }
        //nav
        public virtual Branch Branch { get; set; }
    }
}
