using Application.Common.Validation;
using FluentValidation;

namespace Application.Score.UniversityDegree.Command.Delete;

public sealed class DeleteUniversityDegreeCommandValidator:AbstractValidator<DeleteUniversityDegreeCommand>
{
    public DeleteUniversityDegreeCommandValidator()
    {
        RuleFor(ud => ud.Id)
            .NotEmpty().WithMessage("Id cant be Empty")
            .Must(GuidValidator.BeAValidGuid).WithMessage("Id is not valid Guid type.");
    }
}