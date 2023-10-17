using FluentValidation;
using XPRTZ.BingeMachine.Port;
using XPRTZ.BingeMachine.Shows.Domain;

namespace XPRTZ.BingeMachine.Shows.Fluent.Infrastructure
{
    public class CreateShowCommandValidator : AbstractValidator<CreateShowCommand>
    {
        public CreateShowCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleForEach(x => x.Genres).IsEnumName(typeof(Genre), caseSensitive: false);
        }
    }
}