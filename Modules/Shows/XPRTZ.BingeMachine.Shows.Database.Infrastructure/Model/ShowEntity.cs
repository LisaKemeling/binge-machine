using System.ComponentModel.DataAnnotations.Schema;

namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure.Model
{
    [Table("Show")]
    public class ShowEntity
    {
        public Guid Id { get; set; }
        public int? TvMazeId { get; set; }
        public string Name { get; set; }
        public string? Language { get; set; }
        public DateTime? Premiered { get; set; }
        public string? Summary { get; set; }
        public string? Genres { get; set; }
    }
}
