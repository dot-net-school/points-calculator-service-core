using Application.Common.Validation;
using FluentValidation;

namespace Application.LanguageCertificate.Delete;

public class DeleteLanguageCertificateCommandValidator : AbstractValidator<DeleteLanguageCertificateCommand>
    , IValidatorBase
{
    public DeleteLanguageCertificateCommandValidator()
    {
        RuleFor(lc => lc.Id)
            .NotEmpty().WithMessage("Id cant be null.")
            .Must(GuidValidator.BeAValidGuid).WithMessage("Id is not valid guid type.");
    }
}