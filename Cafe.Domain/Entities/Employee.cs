using Cafe.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Domain
{
    public class Employee : BaseEnt<Guid>
    {
        public string Name { get; set; }
        [MaxLength(50), EmailAddress, RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email may has numbers , characters and ._%+-")]
        public string Phone { get; set; }
        [MaxLength(50), EmailAddress, RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email may has numbers , characters and ._%+-")]
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
