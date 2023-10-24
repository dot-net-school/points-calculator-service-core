using Application.Common.Validation;
using FluentValidation;

namespace Application.Score.Language.Queries.Single;

public class GetSingleLanguageCertificateWithScoreQueryValidator
    :AbstractValidator<GetSingleLanguageCertificateWithScoreQuery> , IValidatorBase
{
    public GetSingleLanguageCertificateWithScoreQueryValidator()
    {
        RuleFor(lc => lc.Id)
            .NotEmpty().WithMessage("Language Certificate Id Cant be Empty")
            .Must(GuidValidator.BeAValidGuid).WithMessage("Id is not valid Guid type.");
    }
}