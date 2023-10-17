namespace XPRTZ.BingeMachine.Shows.Domain
{
    public class Show
    {
        public Guid Id { get; set; }
        public int? TvMazeId { get; set; }
        public required string Name { get; set; }
        public string? Language { get; set; }
        public DateTime? Premiered { get; set; }
        public string? Summary { get; set; }
        public IEnumerable<string> Genres { get; set; }
    }
}