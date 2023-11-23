using FluentValidation;

namespace Application.Score.MaritalStatus.Queries;

public class GetMaritalStatusScoreQueryValidator : AbstractValidator<GetMaritalStatusScoreDto>
{
    public GetMaritalStatusScoreQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ID is required.");
        
        RuleFor(x => x.MaritalStatus)
            .NotEmpty()
            .WithMessage("Marital status cannot be empty.");
        
        RuleFor(x => x.Score)
            .NotNull()
            .WithMessage("Number is required.")
            .GreaterThan(0)
            .WithMessage("Number must be greater than 0.");
    }
}