using AutoMapper;
using Cafe.API_.Dtos.Request.Branch;
using Cafe.API_.Dtos.Request.Table;
using Cafe.API_.Dtos.Response.Branch;
using Cafe.API_.Dtos.Response.Table;
using Cafe.Application.Shared.DTOS.Request;
using Cafe.Application.Shared.DTOS.Request.Table;
using Cafe.Application.Shared.DTOS.Response;
using Cafe.Application.Shared.DTOS.Response.Table;

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

            #region Table
            CreateMap<TableApiCreateDto, TableAppCreateDto>().ReverseMap();
            CreateMap<TableApiUpdateDto, TableAppUpdateDto>().ReverseMap();
            CreateMap<TableAppRespDto, TableApiResponseDto>().ReverseMap();
            #endregion

        }
    }
}
