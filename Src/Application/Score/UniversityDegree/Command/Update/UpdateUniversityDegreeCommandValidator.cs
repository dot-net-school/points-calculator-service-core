using Application.Common.Validation;
using FluentValidation;

namespace Application.Score.UniversityDegree.Command.Update;

public class UpdateUniversityDegreeCommandValidator:AbstractValidator<UpdateUniversityDegreeCommand>
    ,IValidatorBase
{
    public UpdateUniversityDegreeCommandValidator()
    {
        RuleFor(ud => ud.Id)
            .NotEmpty().WithMessage("LanguageScoreId cant be null.")
            .Must(GuidValidator.BeAValidGuid).WithMessage("LanguageScoreId is not valid Guid type.");
    }
}