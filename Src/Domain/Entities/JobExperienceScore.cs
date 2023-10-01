namespace Domain.Entities;

public class JobExperienceScore
{
    public Guid Id { get; set; }
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