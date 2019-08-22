using APITest.Presentation.WebAPI.Models.Domain;
using FluentValidation;

namespace APITest.Presentation.WebAPI.Validations
{
    public class PostUserValidation : AbstractValidator<User>
    {
        public PostUserValidation()
        {
            RuleFor(x => x.name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.age)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThanOrEqualTo(18);
        }
    }
}
