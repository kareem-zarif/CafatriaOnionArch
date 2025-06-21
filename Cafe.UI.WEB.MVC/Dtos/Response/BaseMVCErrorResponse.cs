namespace Cafe.UI.WEB.MVC.Dtos.Response
{
    public class BaseMVCErrorResponse
    {
        public Guid ErrorCode = Guid.NewGuid();
        public string FriendlyErrorMsg { get; set; }
        public List<string> TechErrors { get; set; } = new List<string>();
    }
}
