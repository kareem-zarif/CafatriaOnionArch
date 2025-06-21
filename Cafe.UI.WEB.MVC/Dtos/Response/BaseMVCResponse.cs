using Cafe.Domain.Shared.Enums;

namespace Cafe.UI.WEB.MVC.Dtos.Response
{
    public class BaseMVCResponse<TMVCResDto> where TMVCResDto : class
    {
        public responseResultEnum result { get; set; }
        public TMVCResDto Data { get; set; }
        public BaseMVCErrorResponse errorDetails { get; set; }
    }
}
