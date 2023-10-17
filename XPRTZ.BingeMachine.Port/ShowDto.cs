namespace XPRTZ.BingeMachine.Port;

public class ShowDto
{
    public Guid Id { get; set; }
    public int? TvMazeId { get; set; }
    public string? Name { get; set; }
    public string? Language { get; set; }
    public DateTime? Premiered { get; set; }
    public string? Summary { get; set; }
    public IEnumerable<string>? Genres { get; set; }
}