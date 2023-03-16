namespace TalabaMVC.Models
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public IList<string> Roles { get; set; }

        public Response()
        {
            Roles = new List<string>();
        }
    }
}
