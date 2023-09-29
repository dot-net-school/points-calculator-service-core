namespace Application.Score.Queries.GetJobExperienceScore;

public record GetJobExperienceScoreDto(Guid Id, int MinExperience, int MaxExperience, int Score);