using AutoMapper;
using Cafe.Application.Shared.DTOS.Request;
using Cafe.Application.Shared.DTOS.Response;
using Cafe.UI.WEB.MVC2.ViewModels.Request.Branch;
using Cafe.UI.WEB.MVC2.ViewModels.Response.Branch;

namespace Cafe.UI.WEB.MVC2.AutoMapper
{
    public class MappingMVCProfile : Profile
    {
        public MappingMVCProfile()
        {
            #region Branch
            CreateMap<BranchCreateVM, BranchCreateAppDto>().ReverseMap();
            CreateMap<BranchUpdateVM, BranchUpdateAppDto>().ReverseMap();
            CreateMap<BranchResVM, BranchResAppDto>().ReverseMap();
            #endregion
        }
    }
}
