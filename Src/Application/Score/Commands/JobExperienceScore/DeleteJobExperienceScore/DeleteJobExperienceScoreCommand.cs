using MediatR;

namespace Application.Score.Commands.JobExperienceScore.DeleteJobExperienceScore;

public record DeleteJobExperienceScoreCommand(Guid Id) : IRequest<string>;