using Domain.Common.Enum;
using MediatR;
using Shared;

namespace Application.Score.UniversityDegree.Command.Create;

public record CreateUniversityDegreeCommand(string UniversityName,string DegreeName, byte Score, DegreeLevelEnum? DegreeLevel, SectionTypeEnum? SectionType, bool? IsActive):IRequest<OperationResult<int>>;