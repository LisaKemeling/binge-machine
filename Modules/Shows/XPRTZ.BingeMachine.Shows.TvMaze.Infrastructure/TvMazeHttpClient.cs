using System.Net;
using System.Text.Json;

namespace XPRTZ.BingeMachine.Shows.TvMaze.Infrastructure
{
    public class TvMazeHttpClient : ITvMazeHttpClient
    {
        private readonly HttpClient _httpClient;

        public TvMazeHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Show>> GetShowsAsync(int page = 0)
        {
            int max = 5;
            int retry = 0;
            
            do
            {
                 var response = await _httpClient.GetAsync($"shows?page={page}");
                 if (response.StatusCode == HttpStatusCode.TooManyRequests)
                 {
                     retry++;
                     await Task.Delay(1000);
                 } 
                 else if (response.StatusCode == HttpStatusCode.NotFound)
                 {
                    return new List<Show>();
                 }
                 else
                 {
                     var content = await response.Content.ReadAsStringAsync();
                     return JsonSerializer.Deserialize<IEnumerable<Show>>(content);
                 }
                 
            } while (retry < max);

              
            throw new Exception("Unable to retrieve shows");
            
        }
    }

    public interface ITvMazeHttpClient
    {
        Task<IEnumerable<Show>> GetShowsAsync(int page = 0);
    }
}
