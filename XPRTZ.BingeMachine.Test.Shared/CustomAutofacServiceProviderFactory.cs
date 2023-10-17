using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace XPRTZ.BingeMachine.Test.Shared;

public class CustomAutofacServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
{
    private readonly Action<ContainerBuilder> _configureAction;

    public CustomAutofacServiceProviderFactory(Action<ContainerBuilder> configureAction = null)
    {
        _configureAction = configureAction;
    }

    public ContainerBuilder CreateBuilder(IServiceCollection services)
    {
        var builder = new ContainerBuilder();

        builder.Populate(services);

        return builder;
    }

    public IServiceProvider CreateServiceProvider(ContainerBuilder builder)
    {
        _configureAction?.Invoke(builder);

        var container = builder.Build();

        return new AutofacServiceProvider(container);
    }
}