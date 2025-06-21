using Cafe.Domain.Shared;

namespace Cafe.API_.Dtos.Response.Table
{
    public class TableApiResponseDto
    {
        public Guid Id { get; set; }
        public string TableName { get; set; }
        public byte Capacity { get; set; }
        public TableStatusEnum TableStatus { get; set; }
    }
}
