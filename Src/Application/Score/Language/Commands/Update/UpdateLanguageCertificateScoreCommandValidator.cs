using Application.Common.Validation;
using FluentValidation;

namespace Application.Score.Language.Commands.Update;

public class UpdateLanguageCertificateScoreCommandValidator
    : AbstractValidator<UpdateLanguageCertificateScoreCommand>, IValidatorBase
{
    public UpdateLanguageCertificateScoreCommandValidator()
    {
        RuleFor(lc => lc.LanguageCertificationId)
            .NotEmpty().WithMessage("LanguageCertificationId cant be null.")
            .Must(GuidValidator.BeAValidGuid).WithMessage("LanguageCertificationId is not valid Guid type.");
        RuleFor(ls => ls.Id)
            .NotEmpty().WithMessage("LanguageScoreId cant be null.")
            .Must(GuidValidator.BeAValidGuid).WithMessage("LanguageScoreId is not valid Guid type.");
    }
}