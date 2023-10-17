using System.Net;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using XPRTZ.BingeMachine.Port;
using XPRTZ.BingeMachine.Shows.Application;

namespace XPRTZ.BingeMachine.Shows.WebApi.Infrastructure.Create
{
    [ApiController]
    [Route("shows")]
    public class ShowsController : ControllerBase
    {
        private readonly IRequestHandler<CreateShowCommand, CreateShowResponse> _requestHandler;


        public ShowsController(IRequestHandler<CreateShowCommand, CreateShowResponse> requestHandler)
        {
            _requestHandler = requestHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShowCommand createShow)
        {
            var result = await _requestHandler.HandleAsync(createShow);

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
