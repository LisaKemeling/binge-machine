using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Application.Create.Port
{
    public interface IShowCreator
    {
        Task<Guid> CreateAsync(Show show);
    }
}
