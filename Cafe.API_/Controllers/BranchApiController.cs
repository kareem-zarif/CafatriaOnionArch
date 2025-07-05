


using AutoMapper;
using Cafe.API_.Dtos.Request.Branch;
using Cafe.API_.Dtos.Response;
using Cafe.API_.Dtos.Response.Branch;
using Cafe.Application.Shared.DTOS.Request;
using Cafe.Application.Shared.IServices;
using Cafe.Domain.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.API_.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class BranchApiController : ControllerBase
    {
        private readonly IBranchAppService _branchService;
        private readonly IMapper _mapper;

        public BranchApiController(IBranchAppService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var responseDto = new BaseApiResponse<BranchResponseApiDto>();

            try
            {
                var found = await _branchService.GetAsync(id);
                var mappedDto = _mapper.Map<BranchResponseApiDto>(found);

                responseDto.Result = responseResultEnum.Success;
                responseDto.Data = mappedDto;
            }
            catch (Exception ex)
            {
                responseDto.Result = responseResultEnum.Failed;

                BaseErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"error happens when getting Branch {id}",
                };
                //if (ex.InnerException != null)
                errorResponse.TechErrorMsgs.Add(ex?.ToString() ?? "");

                responseDto.ErrorDetails = errorResponse;
            }

            return Ok(responseDto);
        }

        [HttpGet]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var response = new BaseApiResponse<List<BranchResponseApiDto>>();
            try
            {
                var foundList = await _branchService.GetAsyncAll();
                var mapped = _mapper.Map<List<BranchResponseApiDto>>(foundList);

                response.Result = responseResultEnum.Success;
                response.Data = mapped;
            }
            catch (Exception ex)
            {
                response.Result = responseResultEnum.Failed;

                BaseErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"error when getting all branches"
                };
                errorResponse.TechErrorMsgs.Add(ex?.Message ?? "");
                response.ErrorDetails = errorResponse;
            }

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(BranchCreateApiDto requestDto)
        {
            var response = new BaseApiResponse<BranchResponseApiDto>();
            try
            {
                var mappedGo = _mapper.Map<BranchCreateAppDto>(requestDto);
                var created = await _branchService.CreateAsync(mappedGo);
                var mappedCome = _mapper.Map<BranchResponseApiDto>(created);

                response.Result = responseResultEnum.Success;
                response.Data = mappedCome;
            }
            catch (Exception ex)
            {
                response.Result = responseResultEnum.Failed;

                BaseErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"Failed Create Branch",
                };
                errorResponse.TechErrorMsgs.Add(ex.Message);

                response.ErrorDetails = errorResponse;
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BranchUpdateApiDto reqestDto)
        {
            var response = new BaseApiResponse<BranchResponseApiDto>();

            try
            {
                var mappedGo = _mapper.Map<BranchUpdateAppDto>(reqestDto);
                var updated = await _branchService.UpdateAsync(mappedGo);
                var mappedCome = _mapper.Map<BranchResponseApiDto>(updated);

                response.Result = responseResultEnum.Success;
                response.Data = mappedCome;
            }
            catch (Exception ex)
            {
                response.Result = responseResultEnum.Failed;

                BaseErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"Failed to Updated Branch with Name : {reqestDto.Id}\n location:{reqestDto.Location}"
                };
                errorResponse.TechErrorMsgs.Add(ex.Message);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")] //id here binds the id from the URL path (e.g., /api/BranchApi/123) directly to your method parameter
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = new BaseApiResponse<BranchResponseApiDto>();
            try
            {
                var deleted = await _branchService.DeleteAsync(id);
                var mapped = _mapper.Map<BranchResponseApiDto>(deleted);

                response.Result = responseResultEnum.Success;
                response.Data = mapped;
            }
            catch (Exception ex)
            {
                response.Result = responseResultEnum.Failed;

                BaseErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"Failed Delete Branch with Id : {id}"
                };
                errorResponse.TechErrorMsgs.Add(ex.Message);

                response.ErrorDetails = errorResponse;
            }
            return Ok(response);
        }

    }
}
