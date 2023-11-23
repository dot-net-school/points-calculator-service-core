using Application.Common.Validation;
using Application.DTOs.CustomerService;
using FluentValidation;

namespace Application.Score.TotalScore.Validators;

public sealed class ReceivedMartialDtoValidator:AbstractValidator<ReceivedMaritalDto>,IValidatorBase
{
    public ReceivedMartialDtoValidator()
    {
        RuleFor(rm => rm.Status)
            .NotEmpty().WithMessage("Martial Status cant be bull")
            .GreaterThan(0).WithMessage("Martial status should be number and greater 0");
        RuleFor(rm => rm.SpouseStatus)
            .NotEmpty().WithMessage("Martial Spouse Status cant be null")
            .GreaterThan(0).WithMessage("Martial spouse status should be number and greater than 0");
    }
}