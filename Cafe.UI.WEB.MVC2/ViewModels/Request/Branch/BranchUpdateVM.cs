using Cafe.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Cafe.UI.WEB.MVC2.ViewModels.Request.Branch
{
    public class BranchUpdateVM
    {
        [Required]
        public Guid Id { get; set; }
        [EnumDataType(typeof(BranchLocationEnum))]
        public BranchLocationEnum Location { get; set; } = BranchLocationEnum.Zagazig;
        [Required, MinLength(3), MaxLength(256)]
        public string ManagerName { get; set; }
        public TimeOnly OpenAt { get; set; } = new TimeOnly(9, 0);
        public TimeOnly CloseAt { get; set; } = new TimeOnly(14, 30);
        [Required, MinLength(11), MaxLength(13), Phone]
        [RegularExpression(@"^(010|011|012|15)\d{8,10}$", ErrorMessage = "Phone number must start with 010, 011, or 012 and be between 11 and 13 digits")]
        public string Phone { get; set; }
        [MaxLength(256)]
        public string Address { get; set; }
    }
}
