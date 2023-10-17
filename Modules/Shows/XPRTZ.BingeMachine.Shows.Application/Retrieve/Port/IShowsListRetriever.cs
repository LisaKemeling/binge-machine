using XPRTZ.BingeMachine.Shows.Application.Create.Port;

namespace XPRTZ.BingeMachine.Shows.Application.Retrieve.Port
{
    public interface IShowsListRetriever
    {
        Task<ShowsResult> RetrieveAsync(int skip, int take);
    }
}
