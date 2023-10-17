using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Application.Sync.Port
{
    public interface IShowsSyncPersister
    {
        Task<int> SyncAsync(IEnumerable<Show> shows);
    }
}
