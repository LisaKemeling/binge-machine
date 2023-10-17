using System.Net;
using FluentValidation;
using XPRTZ.BingeMachine.Port;
using XPRTZ.BingeMachine.Shows.Application.Create.Port;
using XPRTZ.BingeMachine.Shows.Domain;


namespace XPRTZ.BingeMachine.Shows.Application.Create
{
    public class CreateShowHandler : IRequestHandler<CreateShowCommand, CreateShowResponse>
    {
       private readonly IValidator<CreateShowCommand> _validator;
       private readonly IShowCreator _showCreator;

       public CreateShowHandler(IValidator<CreateShowCommand> validator, IShowCreator showCreator)
       {
           _validator = validator;
           _showCreator = showCreator;
       }

       public async Task<CreateShowResponse> HandleAsync(CreateShowCommand command)
        {
            var validationResult = _validator.Validate(command);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(failure => $"{failure.PropertyName}: {failure.ErrorMessage}").ToList();
                return new CreateShowResponse() { HttpStatusCode = (int)HttpStatusCode.BadRequest, Errors = errors };
            }

            try
            {
                var result = await _showCreator.CreateAsync(new Show
                {
                    Name = command.Name,
                    Language = command.Language,
                    Premiered = command.Premiered,
                    Summary = command.Summary,
                    Genres = command.Genres
                });

                return new CreateShowResponse { Id = result };
            }
            catch (Exception e)
            {
                return new CreateShowResponse { HttpStatusCode = (int)HttpStatusCode.InternalServerError, Errors = new List<string> { e.Message } };
            }
           
        }
    }
}