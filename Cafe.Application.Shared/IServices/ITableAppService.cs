using Cafe.Application.Shared.DTOS.Request.Table;
using Cafe.Application.Shared.DTOS.Response.Table;

namespace Cafe.Application.Shared.IServices
{
    public interface ITableAppService : IBaseAppService<TableAppCreateDto, TableAppUpdateDto, TableAppRespDto>
    {
    }
}
