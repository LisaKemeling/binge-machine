using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Application.Sync.Port
{
    public interface IShowsRetriever
    {
        Task<List<Show>> RetrieveAsync(int page = 1);
    }
}
