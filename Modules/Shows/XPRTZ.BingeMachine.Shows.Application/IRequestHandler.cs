namespace XPRTZ.BingeMachine.Shows.Application;

public interface IRequestHandler<in TRequest, TResponse> where TRequest : class
{
    Task<TResponse> HandleAsync(TRequest command);
}