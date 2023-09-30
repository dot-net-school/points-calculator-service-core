namespace Application.Score.AgeScore.Queries;

public record AgeScoreDto(Guid Id, int FromAge, int ToAge, int Score);