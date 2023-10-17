
using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace XPRTZ.BingeMachine.Test.Shared;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly Action<ContainerBuilder> _configureAction;

    public CustomWebApplicationFactory(Action<ContainerBuilder> configureAction = null)
    {
        _configureAction = configureAction;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
       
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseServiceProviderFactory(new CustomAutofacServiceProviderFactory(containerbuilder =>
        {
            _configureAction?.Invoke(containerbuilder);

        }));
        return base.CreateHost(builder);
    }


}