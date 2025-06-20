namespace Cafe.API_.Dtos.Response
{
    public class BaseErrorResponse
    {
        public Guid ErrorCode { get; set; } = Guid.NewGuid();
        public string FriendlyErrorMsg { get; set; }
        public List<string> TechErrorMsgs { get; set; } = new List<string>();

    }
}