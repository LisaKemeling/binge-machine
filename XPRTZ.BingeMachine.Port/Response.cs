
namespace XPRTZ.BingeMachine.Port
{
    public class Response
    {
        public int? HttpStatusCode { get; set; }
        public List<string>? Errors { get; set; }
        public bool HasErrors => Errors != null && Errors.Any();
    }
}
