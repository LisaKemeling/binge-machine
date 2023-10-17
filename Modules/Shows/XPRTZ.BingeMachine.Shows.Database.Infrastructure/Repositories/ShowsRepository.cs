
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ShowEntity>> GetShowsAsync(int skip, int take)
        {
            return await _dbContext.Shows.Skip(skip).Take(take).ToListAsync();
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

        public async Task<int> GetShowsCount()
        {
            return await _dbContext.Shows.CountAsync();
        }
    }


    public interface IShowsRepository
    {
        Task<IEnumerable<ShowEntity>> GetShowsAsync(int skip, int take);
        Task<int> AddShowsAsync(IEnumerable<ShowEntity> shows);
        Task<Guid> AddShowAsync(ShowEntity show);
        Task<int> GetShowsCount();
    }
}
