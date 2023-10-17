using Autofac;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Repositories;

namespace XPRTZ.BingeMachine.Shows.FunctionalTests.Shared;

public class TestModule : Module
{
    public TestModule()
    {
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MockShowsRepository>().As<IShowsRepository>().SingleInstance();
    }
}