using Domain.Common;

namespace Domain.Entities;

public class JobExperienceScore : BaseEntity
{
    public int MinExperience { get; set; }
    public int MaxExperience { get; set; }
    public int Score { get; set; }


    public void Update(int minExperience, int maxExperience, int score)
    {
        MinExperience = minExperience;
        MaxExperience = maxExperience;
        Score = score;
    }
}