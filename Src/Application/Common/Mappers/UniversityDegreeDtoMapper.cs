using Application.DTOs;
using Application.Score.UniversityDegree.Queries;
using Domain.Entities;

namespace Application.Common.Mappers;

public sealed class UniversityDegreeDtoMapper
{
    public GetUniversityDegreeDto Mapper(UniversityDegree universityDegree)
    {
        return new GetUniversityDegreeDto(
            universityDegree.Id,
            universityDegree.UniversityName,
            universityDegree.Score.Value,
            universityDegree.IsActive,
            universityDegree.DegreeLevel,
            universityDegree.SectionType);
    }

    public List<GetUniversityDegreeDto> ListMapper(IReadOnlyList<UniversityDegree> universityDegrees)
    {
        return universityDegrees.Select(Mapper).ToList();
    }
}