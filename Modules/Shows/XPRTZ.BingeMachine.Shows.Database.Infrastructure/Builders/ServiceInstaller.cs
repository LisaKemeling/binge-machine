
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure.Builders
{
    public static class ServiceInstaller
    {
        public static IServiceCollection RegisterSqlinfrastructure(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ShowsDbContext>(options =>
                options.UseSqlite(
                    "Data Source=Shows.db",
                    b => b.MigrationsAssembly(typeof(ShowsDbContext).Assembly.FullName)));

            return serviceCollection;
        }
    }
}

//    public class ShowsContextFactory : IDesignTimeDbContextFactory<ShowsDbContext>
//    {
//        public ShowsDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<ShowsDbContext>();
//            optionsBuilder.UseSqlite("Data Source=blog.db");

//            return new ShowsDbContext(optionsBuilder.Options);
//        }
//    }
//}