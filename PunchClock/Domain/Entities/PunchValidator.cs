using FluentValidation;

namespace PunchClock.Domain.Entities
{
    public class PunchValidator: AbstractValidator<Punch>
    {
        public PunchValidator()
        {
            RuleFor(x => x.PunchType)
                .NotEqual(Enums.PunchType.None)
                .WithMessage("Punch type need to be different from 'None'.");
        }
    }
}