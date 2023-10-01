using MediatR;

namespace Application.Score.JobExperience.Commands.CreateJobExperienceScore;

public record CreateJobExperienceScoreCommand(int MinExperience, int MaxExperience, int Score) : IRequest<Guid>;


