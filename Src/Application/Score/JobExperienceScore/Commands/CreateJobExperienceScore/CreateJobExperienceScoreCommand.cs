using MediatR;

namespace Application.Score.JobExperienceScore.Commands.CreateJobExperienceScore;

public record CreateJobExperienceScoreCommand(int MinExperience, int MaxExperience, int Score) : IRequest<Guid>;


