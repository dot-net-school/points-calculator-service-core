using Domain.Common;

namespace Domain.Entities.LanguageScore;

public sealed class LanguageCertification:BaseEntity
{
    public string Name { get; private set; }
    //public bool IsActive { get; private set; }
    public bool IsActive { get; private set; }

    public ICollection<LanguageCertificationScore> LanguageCertificationScores { get; } = new List<LanguageCertificationScore>();

    public LanguageCertification(string name, bool isActive=false)
    {
        Name = name;
        IsActive = isActive;
    }

    public void UpdateName(string? newName)
    {
        if (newName is not null)
        {
            Name = newName;
        }
    }

    public void UpdateActiveness(bool isActive)
    {
        if (isActive)
        {
            IsActive = isActive;
        }
    }
}