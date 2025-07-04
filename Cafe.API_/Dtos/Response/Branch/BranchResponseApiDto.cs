﻿using Cafe.Domain.Shared;

namespace Cafe.API_.Dtos.Response.Branch
{
    public class BranchResponseApiDto
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
