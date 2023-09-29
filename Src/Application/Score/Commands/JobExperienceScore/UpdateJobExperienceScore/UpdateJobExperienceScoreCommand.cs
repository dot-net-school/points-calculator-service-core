using MediatR;

namespace Application.Score.Commands.JobExperienceScore.UpdateJobExperienceScore;

public record UpdateJobExperienceScoreCommand(Guid Id, int MinExperience, int MaxExperience, int Score) : IRequest<string>;

