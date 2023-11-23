using Application.Common.Validation;
using FluentValidation;

namespace Application.Score.TotalScore.Validators;

public class TotalScoreQueryValidator:AbstractValidator<TotalScoreQuery>, IValidatorBase
{
    public TotalScoreQueryValidator()
    {
        RuleFor(ts=>ts.Id)
            .NotEmpty().WithMessage("Language Certificate Id Cant be Empty")
            .Must(GuidValidator.BeAValidGuid).WithMessage("Id is not valid Guid type.");
    }
    
}