using System.ComponentModel.DataAnnotations.Schema;

namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure.Model
{
    [Table("SyncInfo")]
    public class SyncInfoEntity
    {
        public Guid Id { get; set; }
        public int LastTvMazeId { get; set; }
    }
}
