using Cafe.Domain.Shared.Enums;

namespace Cafe.API_.Dtos.Response
{
    //in mvc i return view() / Content() ...
    //in api will return DtoResponse so Wanna General DtoResponse with sepcific criteria 
    public class BaseApiResponse<TApiResponse> where TApiResponse : class
    {
        public responseResultEnum Result { get; set; }
        public TApiResponse Data { get; set; }
        public BaseErrorResponse ErrorDetails { get; set; }
    }
}
