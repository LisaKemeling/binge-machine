namespace XPRTZ.BingeMachine.Port
{
    public class ShowsListResponse : Response
    {
        public IEnumerable<ShowDto> Shows { get; set; }
        public int TotalItems { get; set; }
    }
}
