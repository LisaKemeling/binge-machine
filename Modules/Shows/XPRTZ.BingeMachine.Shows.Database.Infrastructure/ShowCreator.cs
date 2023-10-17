using XPRTZ.BingeMachine.Shows.Application.Create.Port;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Model;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Repositories;
using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure
{
    public class ShowCreator : IShowCreator
    {
        private readonly IShowsRepository _showsRepository;

        public ShowCreator(IShowsRepository showsRepository)
        {
            _showsRepository = showsRepository;
        }

        public async Task<Guid> CreateAsync(Show show)
        {
            return await _showsRepository.AddShowAsync(new ShowEntity
            {
                Name = show.Name,
                Language = show.Language,
                Premiered = show.Premiered,
                Summary = show.Summary,
                Genres = string.Join(',', show.Genres)
            });
        }
    }
}
