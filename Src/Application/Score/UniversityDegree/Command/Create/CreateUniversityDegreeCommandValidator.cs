using Application.Common.Validation;
using FluentValidation;

namespace Application.Score.UniversityDegree.Command.Create;

public sealed class CreateUniversityDegreeCommandValidator:AbstractValidator<CreateUniversityDegreeCommand>,IValidatorBase
{
    public CreateUniversityDegreeCommandValidator()
    {
        RuleFor(ud => ud.Score)
            .NotNull().WithMessage("Score Is Required");
    }
}