using XPRTZ.BingeMachine.Shows.Application.Sync.Port;

namespace XPRTZ.BingeMachine.Shows.TvMaze.Infrastructure
{
    public class ShowsRetriever : IShowsRetriever
    {

        private readonly ITvMazeHttpClient _httpClient;

        public ShowsRetriever(ITvMazeHttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Domain.Show>> RetrieveAsync(int page = 0)
        {
            var shows = await _httpClient.GetShowsAsync(page);
                
            return shows.Where(s => s.Premiered.HasValue && s.Premiered.Value > new DateTime(2014, 01, 01))
                .Select(showStruct => new Domain.Show
                {
                    TvMazeId = showStruct.Id,
                    Name = showStruct.Name,
                    Language = showStruct.Language,
                    Premiered = showStruct.Premiered,
                    Summary = showStruct.Summary,
                    Genres = showStruct.Genres
                }).ToList();
        }
    }
}