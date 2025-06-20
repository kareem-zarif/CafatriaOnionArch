using AutoMapper;
using Cafe.Application.Shared.DTOS.Request;
using Cafe.Application.Shared.DTOS.Response;
using Cafe.Domain;

namespace Cafe.Application.AutoMapper
{
    public class MappingAppProfile : Profile
    {
        public MappingAppProfile()
        {
            //CreateMap<source,Destination>();
            #region Branch
            CreateMap<BranchCreateAppDto, Branch>().ReverseMap();
            CreateMap<BranchUpdateAppDto, Branch>().ReverseMap();
            CreateMap<BranchResAppDto, Branch>().ReverseMap();
            #endregion
        }

    }
}
