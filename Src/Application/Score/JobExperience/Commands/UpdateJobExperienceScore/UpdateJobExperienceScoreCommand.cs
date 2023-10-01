using MediatR;

namespace Application.Score.JobExperience.Commands.UpdateJobExperienceScore;

public record UpdateJobExperienceScoreCommand(Guid Id, int MinExperience, int MaxExperience, int Score) : IRequest<string>;

