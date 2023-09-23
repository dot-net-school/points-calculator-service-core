namespace Application.Score.Queries.GetAllAgeScore;

public record AgeScoreDto(Guid Id, int FromAge, int ToAge, int Score);