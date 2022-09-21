namespace PackageDelivery.Api.Models
{
    public class Error400
    {
        public string message { get; set; }
        public List<string> errors { get; set; }
    }
}