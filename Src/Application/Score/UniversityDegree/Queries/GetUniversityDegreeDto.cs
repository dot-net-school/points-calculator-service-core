using Domain.Common.Enum;

namespace Application.Score.UniversityDegree.Queries;

public record GetUniversityDegreeDto(Guid Id,string UniversityName,byte Score,bool IsActive
    ,DegreeLevelEnum DegreeLevel,SectionTypeEnum SectionType);