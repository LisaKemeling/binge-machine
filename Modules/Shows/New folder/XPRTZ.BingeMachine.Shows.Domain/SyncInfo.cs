using System.ComponentModel.Design;

namespace XPRTZ.BingeMachine.Shows.Domain
{
    public class SyncInfo
    {
        public int? Id { get; set; }    
        public int LatestPage => Id == null ? -1 : (int)Math.Floor((double)Id/250);
    }
}
