using Microsoft.EntityFrameworkCore;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Model;

namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure
{
    public class ShowsDbContext : DbContext
    {
        public DbSet<ShowEntity> Shows { get; set; } 
        public DbSet<SyncInfoEntity?> SyncInfos { get; set; } 

        public ShowsDbContext(DbContextOptions<ShowsDbContext> options) : base(options) { }

    }
}