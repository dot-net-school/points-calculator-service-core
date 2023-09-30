namespace Application.Score.JobExperienceScore.Queries;

public record GetJobExperienceScoreDto(Guid Id, int MinExperience, int MaxExperience, int Score);