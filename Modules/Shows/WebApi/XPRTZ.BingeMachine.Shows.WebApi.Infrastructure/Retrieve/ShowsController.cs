using System.Net;
using Microsoft.AspNetCore.Mvc;
using XPRTZ.BingeMachine.Port;
using XPRTZ.BingeMachine.Shows.Application;

namespace XPRTZ.BingeMachine.Shows.WebApi.Infrastructure.Retrieve
{
    [ApiController]
    [Route("shows")]
    public class ShowsController : ControllerBase
    {
        private readonly IRequestHandler<ShowsQuery, ShowsListResponse> _requestHandler;


        public ShowsController(IRequestHandler<ShowsQuery, ShowsListResponse> requestHandler)
        {
            _requestHandler = requestHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Retrieve([FromQuery] ShowsQuery query)
        {
            var result = await _requestHandler.HandleAsync(query);

            if (result.HasErrors)
            {
                if (result.HttpStatusCode != null &&
                    (HttpStatusCode)result.HttpStatusCode.Value == HttpStatusCode.BadRequest)
                {
                    return BadRequest(result.Errors);
                }

                return new ObjectResult(string.Join(',',result.Errors)){StatusCode = 500};
            }

            return Ok(result);
        }
    }

}
