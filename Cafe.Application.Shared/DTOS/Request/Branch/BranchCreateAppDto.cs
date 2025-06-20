using Cafe.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Cafe.Application.Shared.DTOS.Request
{
    public class BranchCreateAppDto
    {
        public BranchLocationEnum Location { get; set; } = BranchLocationEnum.Zagazig;
        public string ManagerName { get; set; }
        public TimeOnly OpenAt { get; set; } = new TimeOnly(9, 0);
        public TimeOnly CloseAt { get; set; } = new TimeOnly(14, 30);
        [Required, MinLength(11), MaxLength(13), Phone]
        [RegularExpression(@"^(010|011|012|15)\d{8,10}$", ErrorMessage = "Phone number must start with 010, 011, or 012 and be between 11 and 13 digits")]
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
