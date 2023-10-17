
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Model;

namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure.Repositories
{
    public class ShowsRepository : IShowsRepository
    {
        private readonly ShowsDbContext _dbContext;

        public ShowsRepository(ShowsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<ShowEntity>> GetShowsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddShowsAsync(IEnumerable<ShowEntity> shows)
        {
            _dbContext.Shows.AddRange(shows);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Guid> AddShowAsync(ShowEntity show)
        {
            if (show == null) throw new ArgumentNullException(nameof(show));
            _dbContext.Shows.Add(show);
            await _dbContext.SaveChangesAsync();
            return show.Id;
        }
    }


    public interface IShowsRepository
    {
        Task<IEnumerable<ShowEntity>> GetShowsAsync();
        Task<int> AddShowsAsync(IEnumerable<ShowEntity> shows);
        Task<Guid> AddShowAsync(ShowEntity show);

    }
}
