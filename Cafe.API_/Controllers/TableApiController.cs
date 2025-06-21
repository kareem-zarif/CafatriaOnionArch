using AutoMapper;
using Cafe.API_.Dtos.Request.Table;
using Cafe.API_.Dtos.Response;
using Cafe.API_.Dtos.Response.Table;
using Cafe.Application.Shared.DTOS.Request.Table;
using Cafe.Application.Shared.IServices;
using Cafe.Domain.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableApiController : ControllerBase
    {
        private readonly ITableAppService _tableAppService;
        private readonly IMapper _mapper;
        public TableApiController(ITableAppService tableAppService, IMapper mapper)
        {
            _tableAppService = tableAppService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = new BaseApiResponse<TableApiResponseDto>();
            try
            {
                var found = await _tableAppService.GetAsync(id);
                var mapped = _mapper.Map<TableApiResponseDto>(found);

                response.Result = responseResultEnum.Success;
                response.Data = mapped;
            }
            catch (Exception ex)
            {
                response.Result = responseResultEnum.Failed;

                BaseErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"Failed Create Table with Id : {id}"
                };
                errorResponse.TechErrorMsgs.Add(ex.Message);

                response.ErrorDetails = errorResponse;
            }
            return Ok(response);
        }

        [HttpGet]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var response = new BaseApiResponse<List<TableApiResponseDto>>();
            try
            {
                var foundList = await _tableAppService.GetAsyncAll();
                var mapped = _mapper.Map<List<TableApiResponseDto>>(foundList);

                response.Result = responseResultEnum.Success;
                response.Data = mapped;
            }
            catch (Exception ex)
            {
                response.Result = responseResultEnum.Failed;
                BaseErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"failed fetch all Tables"
                };
                errorResponse.TechErrorMsgs.Add($"{ex.Message}");
                response.ErrorDetails = errorResponse;
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TableApiCreateDto requestDto)
        {
            var response = new BaseApiResponse<TableApiResponseDto>();
            try
            {
                var mappedGo = _mapper.Map<TableAppCreateDto>(requestDto);
                var created = await _tableAppService.CreateAsync(mappedGo);
                var mappedCome = _mapper.Map<TableApiResponseDto>(created);

                response.Result = responseResultEnum.Success;
                response.Data = mappedCome;
            }
            catch (Exception ex)
            {
                response.Result = responseResultEnum.Failed;
                BaseErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"Failed Create Table"
                };
                errorResponse.TechErrorMsgs.Add(ex.Message);
                response.ErrorDetails = errorResponse;
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TableApiUpdateDto requestDto)
        {
            var response = new BaseApiResponse<TableApiResponseDto>();
            try
            {
                var mappedGo = _mapper.Map<TableAppUpdateDto>(requestDto);
                var updated = await _tableAppService.UpdateAsync(mappedGo);
                var mappedCome = _mapper.Map<TableApiResponseDto>(updated);

                response.Result = responseResultEnum.Success;
                response.Data = mappedCome;
            }
            catch (Exception ex)
            {
                response.Result = responseResultEnum.Failed;
                BaseErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"failed to Update Table : {requestDto.TableName} with id : {requestDto.Id}"
                };
                errorResponse.TechErrorMsgs.Add($"{ex.Message}");
                response.ErrorDetails = errorResponse;
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = new BaseApiResponse<TableApiResponseDto>();
            try
            {
                var deleted = await _tableAppService.DeleteAsync(id);
                var mapped = _mapper.Map<TableApiResponseDto>(deleted);

                response.Result = responseResultEnum.Success;
                response.Data = mapped;
            }
            catch (Exception ex)
            {
                response.Result = responseResultEnum.Failed;
                BaseErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"Failed delete Table : {id}"
                };
                errorResponse.TechErrorMsgs.Add($"{ex.Message}");
                response.ErrorDetails = errorResponse;
            }
            return Ok(response);
        }
    }
}
