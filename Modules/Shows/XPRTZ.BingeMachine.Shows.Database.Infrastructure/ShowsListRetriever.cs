using System.Web;
using XPRTZ.BingeMachine.Shows.Application.Create.Port;
using XPRTZ.BingeMachine.Shows.Application.Retrieve.Port;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Repositories;
using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure
{
        public class ShowsListRetriever : IShowsListRetriever
    {
        private readonly IShowsRepository _showsRepository;

        public ShowsListRetriever(IShowsRepository showsRepository)
        {
            _showsRepository = showsRepository;
        }

        public async Task<ShowsResult> RetrieveAsync(int skip, int take)
        {
            var shows = await _showsRepository.GetShowsAsync(skip, take);
            var count = await _showsRepository.GetShowsCount();
            return new ShowsResult()
            {
                Shows = shows.Select(x => new Show
                    {
                        Id = x.Id,
                        TvMazeId = x.TvMazeId,
                        Name = HttpUtility.HtmlEncode(x.Name),
                        Language = HttpUtility.HtmlEncode(x.Language),
                        Premiered = x.Premiered,
                        Summary = HttpUtility.HtmlEncode(x.Summary),
                        Genres = !string.IsNullOrEmpty(x.Genres) 
                            ? x.Genres.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                            : new List<string>()
                    }).ToList(),
                TotalItems = count
            };
        }
    }

   
}
