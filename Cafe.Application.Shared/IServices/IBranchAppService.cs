using Cafe.Application.Shared.DTOS.Request;
using Cafe.Application.Shared.DTOS.Response;

namespace Cafe.Application.Shared.IServices
{
    public interface IBranchAppService : IBaseAppService<BranchCreateAppDto, BranchUpdateAppDto, BranchResAppDto>
    {
        // used in AddScoped of service => rather than direct IBaseAppService<BranchCreateAppDto, BranchUpdateAppDto, BranchResAppDto> => for clear readable Dependency Injection and  type safety and  

        //add specific methods for category here
    }
}
