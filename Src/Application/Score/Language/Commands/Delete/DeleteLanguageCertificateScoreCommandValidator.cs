using Application.Common.Validation;
using FluentValidation;

namespace Application.Score.Language.Commands.Delete;

public class DeleteLanguageCertificateScoreCommandValidator
    : AbstractValidator<DeleteLanguageCertificateScoreCommand>, IValidatorBase
{
    public DeleteLanguageCertificateScoreCommandValidator()
    {
        RuleFor(ls => ls.Id)
            .NotEmpty().WithMessage("Id cant be Empty")
            .Must(GuidValidator.BeAValidGuid).WithMessage("Id is not valid Guid type.");
    }
}