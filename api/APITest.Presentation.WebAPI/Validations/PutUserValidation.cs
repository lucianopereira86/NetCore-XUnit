using FluentValidation;

namespace APITest.Presentation.WebAPI.Validations
{
    public class PutUserValidation : PostUserValidation
    {
        public PutUserValidation()
        {
            RuleFor(x => x.id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThan(0);
        }
    }
}
