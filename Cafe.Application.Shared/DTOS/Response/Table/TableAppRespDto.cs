using Cafe.Domain.Shared;

namespace Cafe.Application.Shared.DTOS.Response.Table
{
    public class TableAppRespDto
    {
        public Guid Id { get; set; }
        public string TableName { get; set; }
        public byte Capacity { get; set; }
        public TableStatusEnum TableStatus { get; set; }
    }
}
