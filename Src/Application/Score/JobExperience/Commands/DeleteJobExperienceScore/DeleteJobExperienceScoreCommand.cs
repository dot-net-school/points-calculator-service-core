using MediatR;

namespace Application.Score.JobExperience.Commands.DeleteJobExperienceScore;

public record DeleteJobExperienceScoreCommand(Guid Id) : IRequest<string>;