namespace Application.Score.JobExperience.Queries;

public record GetJobExperienceScoreDto(Guid Id, int MinExperience, int MaxExperience, int Score);