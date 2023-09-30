using MediatR;

namespace Application.Score.JobExperienceScore.Commands.UpdateJobExperienceScore;

public record UpdateJobExperienceScoreCommand(Guid Id, int MinExperience, int MaxExperience, int Score) : IRequest<string>;

