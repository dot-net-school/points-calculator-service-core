using Application.Common.Validation;
using FluentValidation;

namespace Application.LanguageCertificate.Create;

public class CreateLanguageCertificateCommandValidator : AbstractValidator<CreateLanguageCertificateCommand>
    , IValidatorBase
{
    public CreateLanguageCertificateCommandValidator()
    {
        RuleFor(lc => lc.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(30).WithMessage("Max Lenght is 30");
    }
}