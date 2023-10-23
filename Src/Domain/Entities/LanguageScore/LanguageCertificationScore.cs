using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities.LanguageScore;

public sealed class LanguageCertificationScore:BaseEntity
{
    public Score Score { get; private set; }
    //TODO we dont update it frequently nad it doesnt have special logic, so define it as private setter is good approach? avoid encapsulation?
    //for NAATI CCL its nullable
    //TODO it can become valueObject?
    public string? Mark { get; private set; }
    public bool IsActive { get; private set; }
    [Required]
    public Guid LanguageCertificationId { get; set; }
    //TODO place for ensure language certification is exist in application layer is good approach?
    public LanguageCertification LanguageCertification { get; set; } = null!;

   //TODO how about to make LanguageCertification nullable? and LanguageCertificationId required?  for make constructor smaller but in service layer we will be assure that LanguageCertification is exist in db
    
    
    public LanguageCertificationScore(Score score, string? mark, Guid languageCertificationId,
        bool isActive=false) : this(mark, languageCertificationId,isActive)
    {
        Score = score;
    }
    /// <summary>
    /// EF constructor
    /// </summary>
    private LanguageCertificationScore(string? mark, Guid languageCertificationId,bool isActive=false)
    {
        Mark = mark;
        LanguageCertificationId = languageCertificationId;
        IsActive = isActive;
    }
    public void UpdateScore(Score? newScore)
    {
        if (newScore is not null)
        {
            Score = newScore;
        }
    }
    public void UpdateMark(string? newMark)
    {
        if (newMark is not null)
        {
            Mark = newMark;
        }
    }

    public void UpdateActiveness(bool? isActive)
    {
        if (isActive.HasValue)
        {
            IsActive = isActive.Value;
        }
    }
   
}