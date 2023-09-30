namespace Domain.Entities;

public class AgeScore
{
    public Guid Id { get; set; }
    public int FromAge { get; set; }
    public int ToAge { get; set; }
    public int Score { get; set; }
    public AgeScore(int fromAge, int toAge, int score)
    {
        Id = Guid.NewGuid();
        FromAge = fromAge;
        ToAge = toAge;
        Score = score;
    }
    public void Update(int fromAge, int toAge, int score)
    {
        Score = score;
        FromAge = fromAge;
        ToAge = toAge;
    }
}
