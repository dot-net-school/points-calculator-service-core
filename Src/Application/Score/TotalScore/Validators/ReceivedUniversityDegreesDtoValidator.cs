using Application.Common.Validation;
using Application.DTOs.UniversityDegree;
using FluentValidation;

namespace Application.Score.TotalScore.Validators;

public sealed class ReceivedUniversityDegreesDtoValidator:AbstractValidator<ReceivedUniversityDegreesDto>,IValidatorBase
{
    public ReceivedUniversityDegreesDtoValidator()
    {
        RuleFor(ru => ru.DegreeName)
            .NotEmpty().WithMessage("university name ant be empty");
        RuleFor(ru => ru.UniversityName)
            .NotEmpty().WithMessage("degree name cant be empty");
        RuleFor(ru=>ru.Id)
            .NotEmpty().WithMessage("university id ant be empty")
            .Must(GuidValidator.BeAValidGuid).WithMessage("university Id is not valid Guid type.");
    }
}