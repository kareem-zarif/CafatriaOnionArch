using Cafe.Domain.Shared;

namespace Cafe.UI.WEB.MVC2.ViewModels.Response.Branch
{
    public class BranchResVM
    {
        public Guid Id { get; set; }
        public BranchLocationEnum Location { get; set; }
        public string ManagerName { get; set; }
        public TimeOnly OpenAt { get; set; }
        public TimeOnly CloseAt { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
