using Cafe.Domain.CoreInterfaces.IIntegrations;
using Cafe.Domain.Shared.Enums;
using Cafe.UI.WEB.MVC.Dtos;
using Cafe.UI.WEB.MVC.Dtos.Request.Branch;
using Cafe.UI.WEB.MVC.Dtos.Response;
using Cafe.UI.WEB.MVC.Dtos.Response.Branch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Cafe.UI.WEB.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : Controller
    {
        private readonly ICafeHTTPClientService _clientHTTPService;
        private readonly IConfiguration _config; // to get static pathes
        private readonly HTTPClientSettings _httpSettings;
        public BranchController(ICafeHTTPClientService clientHTTPService, IConfiguration config, IOptions<HTTPClientSettings> httpSettingsOptions)
        //IOptions<HTTPClientSettings> => return configurations   
        {
            _clientHTTPService = clientHTTPService;
            _config = config;
            _httpSettings = httpSettingsOptions.Value;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {

            var response = new BaseMVCResponse<List<BranchResMvcDto>>();
            try
            {
                var result = await _clientHTTPService.GetAllAsync<List<BranchResMvcDto>>(
                    string.Format($"{_httpSettings.BaseUrl.TrimEnd('/')}/{_httpSettings.GetAllBranches.TrimStart('/')}")
                );

                response.result = responseResultEnum.Success;
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.result = responseResultEnum.Failed;
                BaseMVCErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"failed to fetch all Branches"
                };
                errorResponse.TechErrors.Add(ex.ToString());
                response.errorDetails = errorResponse;
            }

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BranchCreateMvcDto requestDto)
        {
            var response = new BaseMVCResponse<BranchResMvcDto>();
            try
            {
                var result = await _clientHTTPService.PostAsync<BranchCreateMvcDto, BranchResMvcDto>(
                    _config.GetSection("HTTPClientSettings:StaticEndpoints:Branches").Value, requestDto
                    );

                response.result = responseResultEnum.Success;
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.result = responseResultEnum.Failed;
                BaseMVCErrorResponse errorResponse = new()
                {
                    FriendlyErrorMsg = $"Failed Create Branch {requestDto.Location}"
                };
                errorResponse.TechErrors.Add(ex.Message);
                response.errorDetails = errorResponse;
            }
            return Json(response);
        }
    }
}
