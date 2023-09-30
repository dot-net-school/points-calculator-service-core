using MediatR;

namespace Application.Score.JobExperienceScore.Commands.DeleteJobExperienceScore;

public record DeleteJobExperienceScoreCommand(Guid Id) : IRequest<string>;