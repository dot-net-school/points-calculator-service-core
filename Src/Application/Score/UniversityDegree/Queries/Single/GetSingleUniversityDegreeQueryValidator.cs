using Application.Common.Validation;
using FluentValidation;

namespace Application.Score.UniversityDegree.Queries;

public class GetSingleUniversityDegreeQueryValidator:AbstractValidator<GetSingleUniversityDegreeQuery>
{
    public GetSingleUniversityDegreeQueryValidator()
    {
        RuleFor(ud => ud.Id)
            .NotEmpty().WithMessage("Id Cant be Empty.")
            .Must(GuidValidator.BeAValidGuid).WithMessage("Id Must Be Valid Guid Type.");
    }
}