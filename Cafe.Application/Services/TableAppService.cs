using AutoMapper;
using Cafe.Application.Shared.DTOS.Request.Table;
using Cafe.Application.Shared.DTOS.Response.Table;
using Cafe.Application.Shared.IServices;
using Cafe.Domain;
using Cafe.Domain.CoreInterfaces;
using Cafe.Domain.CoreInterfaces.IUOW;

namespace Cafe.Application.Services
{
    public class TableAppService : BaseAppService<Table, TableAppCreateDto, TableAppUpdateDto, TableAppRespDto>, ITableAppService
    {
        public TableAppService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IBaseRepo<Table, Guid> _baseRepo => _unitOfWork.TableRepo;
    }
}
