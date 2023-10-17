using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Model;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Repositories;
using XPRTZ.BingeMachine.Shows.DeserializerTests;

namespace XPRTZ.BingeMachine.Shows.FunctionalTests.Shared;

public class MockShowsRepository : IShowsRepository
{
    private List<ShowEntity> _dummyData;

    public MockShowsRepository()
    {
        var dummy = new DummyData();
        _dummyData = dummy.Shows.Select(s => new ShowEntity
        {
            Id = Guid.NewGuid(),
            TvMazeId = s.Id,
            Name = s.Name,
            Language = s.Language,
            Premiered = s.Premiered,
            Summary = s.Summary,
            Genres = string.Join(", ", s.Genres)
        }).ToList();
    }

    public Task<IEnumerable<ShowEntity>> GetShowsAsync()
    {
        return Task.FromResult(_dummyData.AsEnumerable());
    }

    public Task<int> AddShowsAsync(IEnumerable<ShowEntity> shows)
    {
        return Task.FromResult(shows.Count());
    }

    public Task<Guid> AddShowAsync(ShowEntity show)
    {
        return Task.FromResult(Guid.NewGuid());
    }
}