using Domain.Common;

namespace Domain.Entities;

public class AgeScore : BaseEntity
{
    public required int FromAge { get; set; }
    public int ToAge { get; set; }
    public int Score { get; set; }
    
    public void Update(int fromAge, int toAge, int score)
    {
        Score = score;
        FromAge = fromAge;
        ToAge = toAge;
    }
}