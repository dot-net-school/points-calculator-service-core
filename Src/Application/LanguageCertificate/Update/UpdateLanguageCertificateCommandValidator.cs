using Application.Common.Validation;
using FluentValidation;

namespace Application.LanguageCertificate.Update;

public class UpdateLanguageCertificateCommandValidator : AbstractValidator<UpdateLanguageCertificateCommand>
    , IValidatorBase
{
    public UpdateLanguageCertificateCommandValidator()
    {
        RuleFor(lc => lc.Id)
            .NotEmpty().WithMessage("Id cant be null.")
            .Must(GuidValidator.BeAValidGuid).WithMessage("Id is not valid guid type.");
    }
}