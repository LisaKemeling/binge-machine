using FluentValidation;
using XPRTZ.BingeMachine.Port;

namespace XPRTZ.BingeMachine.Shows.Fluent.Infrastructure
{
    public class ShowsQueryValidator : AbstractValidator<ShowsQuery>
    {
        public ShowsQueryValidator()
        {
            RuleFor(e => e.Skip).GreaterThanOrEqualTo(0);
            RuleFor(e => e.Take).GreaterThanOrEqualTo(0);
        }
    }
}