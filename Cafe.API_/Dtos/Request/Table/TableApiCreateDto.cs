using Cafe.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Cafe.API_.Dtos.Request.Table
{
    public class TableApiCreateDto
    {
        [Required(ErrorMessage = "Table Name is reqired"), MaxLength(64)]
        public string TableName { get; set; }
        [Required, Range(1, 10, ErrorMessage = "Table Capacity 1 : 10")]
        public byte Capacity { get; set; }
        [EnumDataType(typeof(TableStatusEnum))] //prevent invalid or out-of-range enum values from being accepted by your API.
        public TableStatusEnum TableStatus { get; set; } = TableStatusEnum.Available;
    }
}
