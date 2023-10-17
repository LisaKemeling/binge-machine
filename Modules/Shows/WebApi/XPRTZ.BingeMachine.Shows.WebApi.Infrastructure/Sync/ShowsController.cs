using Microsoft.AspNetCore.Mvc;
using XPRTZ.BingeMachine.Port;
using XPRTZ.BingeMachine.Shows.Application;
using XPRTZ.BingeMachine.Shows.Application.Sync;
using XPRTZ.BingeMachine.Shows.TvMaze.Infrastructure;

namespace XPRTZ.BingeMachine.Shows.WebApi.Infrastructure.Sync
{
    [ApiController]
    [Route("shows")]
    public class ShowsController : ControllerBase
    {
        private readonly IRequestHandler<SyncShowsCommand, SyncShowsResponse> _requestHandler;

        public ShowsController(IRequestHandler<SyncShowsCommand, SyncShowsResponse> requestHandler)
        {
            _requestHandler = requestHandler;
        }


        [HttpPost]
        [Route("sync")]
        public async Task<IActionResult> SyncShows()
        {
            var result = await _requestHandler.HandleAsync(new SyncShowsCommand());
            return Ok();
        }
    }

}
