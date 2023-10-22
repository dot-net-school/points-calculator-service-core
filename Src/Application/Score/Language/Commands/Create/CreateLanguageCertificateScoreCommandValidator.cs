using Application.Common.Validation;
using FluentValidation;

namespace Application.Score.Language.Commands.Create;

public class CreateLanguageCertificateScoreCommandValidator : AbstractValidator<CreateLanguageCertificateScoreCommand>
    , IValidatorBase
{
    public CreateLanguageCertificateScoreCommandValidator()
    {
        RuleFor(ls => ls.Score)
            .NotNull().WithMessage("Score is required");
        RuleFor(ls => ls.LanguageCertificationId)
            .NotEmpty().WithMessage("LanguageCertificationId cant be Empty.")
            .Must(GuidValidator.BeAValidGuid).WithMessage("LanguageCertificationId is not valid Guid type.");
        //TODO add more validation for bool
    }
}