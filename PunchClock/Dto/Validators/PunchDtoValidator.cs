using FluentValidation;

namespace PunchClock.Dto.Validators
{
    public class PunchDtoValidator: AbstractValidator<PunchDto>
    {
        public PunchDtoValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty().WithMessage("There's no employee");
        }
    }
}