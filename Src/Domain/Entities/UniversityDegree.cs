using Domain.Common;
using Domain.Common.Enum;
using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class UniversityDegree : BaseEntity
{
    public string UniversityName { get; set; }
    public string DegreeName { get; set; }
    public DegreeLevelEnum DegreeLevel { get; set; }
    public SectionTypeEnum SectionType { get; set; }
    //TODO WHy it should be null when its default value is null?
    public bool IsActive { get; set; } = false;
    public Score Score { get; set; }

    public UniversityDegree()
    {
    }
    public UniversityDegree(Score score, string universityName,string degreeName, DegreeLevelEnum degreeLevel,
        SectionTypeEnum sectionType,bool isActive):this( universityName, degreeName, degreeLevel,
         sectionType, isActive)
    {
        Score = score;
    }

    //Constructor for EF
    private UniversityDegree(string universityName,string degreeName, DegreeLevelEnum degreeLevel,
        SectionTypeEnum sectionType,bool isActive)
    {
        UniversityName = universityName;
        DegreeName = degreeName;
        DegreeLevel = degreeLevel;
        SectionType = sectionType;
        IsActive = isActive;
    }
}