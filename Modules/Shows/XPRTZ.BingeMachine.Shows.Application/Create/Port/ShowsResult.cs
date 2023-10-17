using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Application.Create.Port
{
    public class ShowsResult
    {
        public List<Show> Shows { get; set; }
        public int TotalItems { get; set; }
    }
}
