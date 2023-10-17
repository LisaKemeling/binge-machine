using XPRTZ.BingeMachine.Shows.Application.Sync.Port;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Model;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Repositories;
using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure
{
    public class ShowsSyncPersister : IShowsSyncPersister
    {
        private readonly IShowsRepository _showsRepository;

        public ShowsSyncPersister(IShowsRepository showsRepository)
        {
            _showsRepository = showsRepository;
        }

        public async Task<int> SyncAsync(IEnumerable<Show> shows)
        {
            try
            {
                return await _showsRepository.AddShowsAsync(shows.Select(show => new ShowEntity
                {
                    TvMazeId = show.TvMazeId,
                    Name = show.Name,
                    Language = show.Language,
                    Premiered = show.Premiered,
                    Summary = show.Summary,
                    Genres = string.Join(", ", show.Genres)
                }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
