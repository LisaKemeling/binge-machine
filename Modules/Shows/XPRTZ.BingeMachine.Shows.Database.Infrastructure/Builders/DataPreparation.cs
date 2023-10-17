#region

#endregion

using Microsoft.EntityFrameworkCore;

namespace XPRTZ.BingeMachine.Shows.Database.Infrastructure.Builders
{
    public static class DataPreparation
    {
        public static void PrepareDatabase(this ShowsDbContext showsContext)
        {
            showsContext.Database.Migrate();
        }
    }
}