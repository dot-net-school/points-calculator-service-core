using Application.Common.Validation;
using Application.DTOs.Language;
using FluentValidation;

namespace Application.Score.TotalScore.Validators;

public sealed class ReceivedLanguageScoreDtoValidator: AbstractValidator<ReceivedLanguageDegreeDto>,IValidatorBase
{
    public ReceivedLanguageScoreDtoValidator()
    {
        RuleFor(rl=>rl.Id)
            .NotEmpty().WithMessage("Language Certificate Score id cant be empty")
            .Must(GuidValidator.BeAValidGuid).WithMessage("Language Certificate Score Id is not valid Guid type.");
        RuleFor(rl => rl.Mark)
            .NotEmpty().WithMessage("Language Certificate Mark Cant be null");
        RuleFor(rl => rl.Name)
            .NotEmpty().WithMessage("Language Certificate name cant be null");
    }
}