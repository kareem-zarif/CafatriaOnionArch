using AutoMapper;
using Cafe.API_.Dtos.Request.Branch;
using Cafe.API_.Dtos.Response.Branch;
using Cafe.Application.Shared.DTOS.Request;
using Cafe.Application.Shared.DTOS.Response;

namespace Cafe.API_.AutoMapper
{
    public class MappingApiProfile : Profile
    {
        public MappingApiProfile()
        {
            // CreateMap<Source, Destination>()
            #region Branch
            CreateMap<BranchCreateApiDto, BranchCreateAppDto>().ReverseMap();
            CreateMap<BranchUpdateApiDto, BranchUpdateAppDto>().ReverseMap();
            CreateMap<BranchResAppDto, BranchResponseApiDto>().ReverseMap();
            #endregion

        }
    }
}
