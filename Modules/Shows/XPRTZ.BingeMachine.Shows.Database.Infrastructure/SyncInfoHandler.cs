using XPRTZ.BingeMachine.Shows.Application.Sync.Port;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Model;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Repositories;
using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure
{
    public class SyncInfoHandler : ISyncInfoHandler
    {
        private readonly ISyncInfoRepository _syncInfoRepository;

        public SyncInfoHandler(ISyncInfoRepository syncInfoRepository)
        {
            _syncInfoRepository = syncInfoRepository;
        }

        public async Task<SyncInfo> RetrieveAsync()
        {
            var dbResult = await _syncInfoRepository.GetLatest();
            return dbResult == null ? new SyncInfo() : new SyncInfo() { Id = dbResult.LastTvMazeId };

        }

        public async Task<int> AddAsync(SyncInfo info)
        {
            if (!info.Id.HasValue) return 0;
            return await _syncInfoRepository.AddAsync(new SyncInfoEntity
            {
                LastTvMazeId = info.Id.Value
            });
        }
    }
}
