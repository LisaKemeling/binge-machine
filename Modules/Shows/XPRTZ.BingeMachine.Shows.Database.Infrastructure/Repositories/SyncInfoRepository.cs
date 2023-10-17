using Microsoft.EntityFrameworkCore;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Model;

namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure.Repositories
{
    public class SyncInfoRepository : ISyncInfoRepository
    {
        private readonly ShowsDbContext _dbContext;

        public SyncInfoRepository(ShowsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SyncInfoEntity?> GetLatest()
        {
            return await _dbContext.SyncInfos
                .OrderByDescending(i => i!.LastTvMazeId)
                .FirstOrDefaultAsync();
        }

        public async Task<int> AddAsync(SyncInfoEntity? entity)
        {
                _dbContext.SyncInfos.Add(entity);
                return await _dbContext.SaveChangesAsync();
        }
    }


    public interface ISyncInfoRepository
    {
        Task<SyncInfoEntity?> GetLatest();
        Task<int> AddAsync(SyncInfoEntity? entity);

    }
}
