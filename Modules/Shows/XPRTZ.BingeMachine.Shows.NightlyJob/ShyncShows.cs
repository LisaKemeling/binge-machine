using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Model;
using XPRTZ.BingeMachine.Shows.TvMaze.Infrastructure;

namespace XPRTZ.BingeMachine.Shows.NightlyJob
{
    public class ShyncShows
    {

        [FunctionName("SyncShows")]
        public async Task Run([TimerTrigger("0 0 */24 * * *", RunOnStartup = true)]TimerInfo myTimer)
        {
            //api client to target this api and trigger
        }
    }
}
