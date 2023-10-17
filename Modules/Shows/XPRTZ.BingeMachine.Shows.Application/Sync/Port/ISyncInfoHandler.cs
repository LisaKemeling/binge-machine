using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Application.Sync.Port
{
    public interface ISyncInfoHandler
    {
        Task<SyncInfo> RetrieveAsync();
        Task<int> AddAsync(SyncInfo info);
    }
}
