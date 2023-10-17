
using XPRTZ.BingeMachine.Port;
using XPRTZ.BingeMachine.Shows.Application.Sync.Port;
using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Application.Sync
{
    public class SyncShowsHandler : IRequestHandler<SyncShowsCommand, SyncShowsResponse>
    {
        private readonly IShowsRetriever _showsRetriever;
        private readonly ISyncInfoHandler _syncInfoHandler;
        private readonly IShowsSyncPersister _showsSyncPersister;

        public SyncShowsHandler(IShowsRetriever showsRetriever, ISyncInfoHandler syncInfoHandler, IShowsSyncPersister showsSyncPersister)
        {
            _showsRetriever = showsRetriever;
            _syncInfoHandler = syncInfoHandler;
            _showsSyncPersister = showsSyncPersister;
        }

        public async Task<SyncShowsResponse> HandleAsync(SyncShowsCommand command)
        {
            var syncInfo = await _syncInfoHandler.RetrieveAsync();
            var retrievedShows = new List<Show>();

            try
            {
                await GetShows(syncInfo, retrievedShows);

            }
            catch (Exception e)
            {
                await _syncInfoHandler.AddAsync(syncInfo);
                await _showsSyncPersister.SyncAsync(retrievedShows);
                throw;
            }

           await _showsSyncPersister.SyncAsync(retrievedShows);
           return new SyncShowsResponse()
           {
               SyncedShowsCount = retrievedShows.Count
           };
        }

        private async Task GetShows(SyncInfo syncInfo, List<Show> retrievedShows)
        {
            var shows = await _showsRetriever.RetrieveAsync(syncInfo.LatestPage + 1);

            if (shows.Any())
            {
                retrievedShows.AddRange(shows);
                syncInfo.Id = shows.Last().TvMazeId;

                await GetShows(syncInfo, retrievedShows); 
            }
            else
            {
                await _syncInfoHandler.AddAsync(syncInfo);
            }
        }

    }
}