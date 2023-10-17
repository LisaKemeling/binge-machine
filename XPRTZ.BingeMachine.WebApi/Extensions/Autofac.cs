using Autofac;
using XPRTZ.BingeMachine.Shows.Init;

namespace XPRTZ.BingeMachine.WebApi.Extensions
{
    public static class AutofacModulesRegistration
    {
        public static void RegisterAutofacModules(this ContainerBuilder containerBuilder, WebApplicationBuilder builder)
        {
            containerBuilder.RegisterModule(new ShowsModule());
        }
    }
}
