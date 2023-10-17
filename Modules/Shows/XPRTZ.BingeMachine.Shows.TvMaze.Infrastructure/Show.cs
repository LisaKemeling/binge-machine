using System.Text.Json.Serialization;

namespace XPRTZ.BingeMachine.Shows.TvMaze.Infrastructure;

public struct Show
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("premiered")]
    public DateTime? Premiered { get; set; }

    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    [JsonPropertyName("genres")]
    public IEnumerable<string> Genres { get; set; }

}
