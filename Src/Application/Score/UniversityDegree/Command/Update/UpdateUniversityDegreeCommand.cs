using Domain.Common.Enum;
using MediatR;
using Shared;

namespace Application.Score.UniversityDegree.Command.Update;

public record UpdateUniversityDegreeCommand(string? Id, string UniversityName,string DegreeName, DegreeLevelEnum? DegreeLevel,
    SectionTypeEnum? SectionType, byte Score,bool? IsActive):IRequest<OperationResult<int>>;