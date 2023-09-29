namespace Domain.Entities.JobExperienceScoreEntity;

public class JobExperienceScore
{
    public Guid Id { get; set; }
    public int MinExperience { get; set; }
    public int MaxExperience { get; set; }
    public int Score { get; set; }

    public JobExperienceScore(int minExperience, int maxExperience, int score)
    {
        Id = Guid.NewGuid();
        MinExperience = minExperience;
        MaxExperience = maxExperience;
        Score = score;
    }


    public void Update(int minExperience, int maxExperience, int score)
    {
        MinExperience = minExperience;
        MaxExperience = maxExperience;
        Score = score;
    }
}