using System.Net;
using FluentValidation;
using XPRTZ.BingeMachine.Port;
using XPRTZ.BingeMachine.Shows.Application.Retrieve.Port;

namespace XPRTZ.BingeMachine.Shows.Application.Retrieve
{
    public class ListShowsHandler : IRequestHandler<ShowsQuery, ShowsListResponse>
    { 
        
        private readonly IShowsListRetriever _showsRetriever;
        private readonly IValidator<ShowsQuery> _validator;

        public ListShowsHandler(IShowsListRetriever showsRetriever, IValidator<ShowsQuery> validator)
        {
            _showsRetriever = showsRetriever;
            _validator = validator;
        }

        public async Task<ShowsListResponse> HandleAsync(ShowsQuery command)
        {
            var validationResult = _validator.Validate(command);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(failure => $"{failure.PropertyName}: {failure.ErrorMessage}").ToList();
                return new ShowsListResponse() { HttpStatusCode = (int)HttpStatusCode.BadRequest, Errors = errors };
            }

            var result = await _showsRetriever.RetrieveAsync(command.Skip, command.Take);
            
            return new ShowsListResponse()
            {
                Shows = result.Shows.Select(show => new ShowDto
                {
                    Id = show.Id,
                    TvMazeId = show.TvMazeId,
                    Name = show.Name,
                    Language = show.Language,
                    Premiered = show.Premiered,
                    Summary = show.Summary,
                    Genres = show.Genres.ToList() 
                }),
                TotalItems = result.TotalItems
            };
        }

    }
}