using AutoMapper;
using Cafe.Application.Shared.DTOS.Request;
using Cafe.Application.Shared.DTOS.Response;
using Cafe.Application.Shared.IServices;
using Cafe.Domain;
using Cafe.Domain.CoreInterfaces;
using Cafe.Domain.CoreInterfaces.IUOW;

namespace Cafe.Application.Services
{
    public class BranchAppService : BaseAppService<Branch, BranchCreateAppDto, BranchUpdateAppDto, BranchResAppDto>, IBranchAppService
    {
        public BranchAppService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IBaseRepo<Branch, Guid> _baseRepo => _unitOfWork.BranchRepo;
    }
}
