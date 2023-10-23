using FluentValidation;

namespace Application.Score.MaritalStatus.Commands.CreateMaritalStatusScore;

    public class CreateMaritalStatusScoreCommandValidator : AbstractValidator<CreateMaritalStatusScoreCommand>
    {
        public CreateMaritalStatusScoreCommandValidator()
        {
            RuleFor(x => x.MaritalStatus)
                .NotEmpty()
                .WithMessage("Marital status cannot be empty.")
                .MaximumLength(50)
                .WithMessage("Marital status must be less than 50");

            RuleFor(x => x.Score)
                .NotNull()
                .WithMessage("Number is required.")
                .GreaterThan(0)
                .WithMessage("Number must be greater than 0.");
        }
    }

