using MediatR;

namespace Application.Score.Commands.JobExperienceScore.CreateJobExperienceScore;

public record CreateJobExperienceScoreCommand(int MinExperience, int MaxExperience, int Score) : IRequest<Guid>;


