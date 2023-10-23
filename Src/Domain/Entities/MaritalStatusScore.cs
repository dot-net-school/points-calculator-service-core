using Domain.Common;

namespace Domain.Entities;

public class MaritalStatusScore:BaseEntity
{
    public Guid Id { get; set; }
    public string MaritalStatus { get; set; }
    public int Score { get; set; }

    public void Update(int score)
    {
        Score = score;
    }
}