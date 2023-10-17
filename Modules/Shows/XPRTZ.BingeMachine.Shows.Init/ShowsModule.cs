using System.Reflection;
using Autofac;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Infrastructure;
using XPRTZ.BingeMachine.Port;
using XPRTZ.BingeMachine.Shows.Application;
using XPRTZ.BingeMachine.Shows.Application.Create.Port;
using XPRTZ.BingeMachine.Shows.Application.Retrieve.Port;
using XPRTZ.BingeMachine.Shows.Application.Sync;
using XPRTZ.BingeMachine.Shows.Application.Sync.Port;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Repositories;
using XPRTZ.BingeMachine.Shows.Fluent.Infrastructure;
using XPRTZ.BingeMachine.Shows.TvMaze.Infrastructure;
using Module = Autofac.Module;

namespace XPRTZ.BingeMachine.Shows.Init
{
    public class ShowsModule : Module
    {
        public ShowsModule()
        {
            
        }

        protected override void Load(ContainerBuilder builder)
        { 
            builder.RegisterAssemblyTypes(typeof(SyncShowsHandler).Assembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>))
                    .InstancePerLifetimeScope();

            builder.RegisterType<SyncInfoHandler>().As<ISyncInfoHandler>().InstancePerLifetimeScope();
            builder.RegisterType<ShowsSyncPersister>().As<IShowsSyncPersister>().InstancePerLifetimeScope();
            builder.RegisterType<ShowsRetriever>().As<IShowsRetriever>().InstancePerLifetimeScope();
            builder.RegisterType<ShowCreator>().As<IShowCreator>().InstancePerLifetimeScope();
            builder.RegisterType<ShowsListRetriever>().As<IShowsListRetriever>().InstancePerLifetimeScope();

            builder.RegisterType<SyncInfoRepository>().As<ISyncInfoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ShowsRepository>().As<IShowsRepository>().InstancePerLifetimeScope();

            builder.RegisterType<CreateShowCommandValidator>().As<IValidator<CreateShowCommand>>().InstancePerLifetimeScope();
            builder.RegisterType<ShowsQueryValidator>().As<IValidator<ShowsQuery>>().InstancePerLifetimeScope();

        }
    }
}