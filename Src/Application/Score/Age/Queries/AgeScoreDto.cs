namespace Application.Score.Age.Queries;

public record AgeScoreDto(Guid Id, int FromAge, int ToAge, int Score);