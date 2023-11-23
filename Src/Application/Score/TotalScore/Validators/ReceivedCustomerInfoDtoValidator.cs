using Application.Common.Validation;
using Application.DTOs.CustomerService;
using Application.Score.TotalScore.Validators;
using FluentValidation;

namespace Application.Score.TotalScore;

public sealed class ReceivedCustomerInfoDtoValidator : AbstractValidator<ReceivedCustomerInfoDto>, IValidatorBase
{
    public ReceivedCustomerInfoDtoValidator()
    {
        RuleFor(rc => rc.Id)
            .NotEmpty().WithMessage("Received Customer Certificate Id Cant be Empty")
            .Must(GuidValidator.BeAValidGuid).WithMessage("Id is not valid Guid type.");

        RuleFor(rc => rc.Age)
            .GreaterThan(0).WithMessage("Number of Age must be greater than 0.")
            .Unless(rc => rc.Age is null);

        When(rc => rc.Marital is not null,
            () => { RuleFor(rc => rc.Marital).SetValidator(new ReceivedMartialDtoValidator()); });

        When(rc => rc.UniversityDegrees is not null && !rc.UniversityDegrees.Any(),
            () =>
            {
                RuleFor(rc => rc.UniversityDegrees).ForEach(rc => rc.SetValidator(new ReceivedUniversityDegreesDtoValidator()));
            });

        When(rc => rc.LanguageDegrees is not null && !rc.LanguageDegrees.Any(),
            () =>
            {
                RuleFor(rc => rc.LanguageDegrees).ForEach(rc => rc.SetValidator(new ReceivedLanguageScoreDtoValidator()));
            });

        RuleFor(rc => rc.JobExperience)
            .GreaterThan(0).WithMessage("Number of Job Experience Must Be greater Than 0.")
            .Unless(rc => rc.JobExperience == null);
    }
}