using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.DeleteJobExperienceScore;

public record DeleteJobExperienceScoreCommand(Guid Id) : IRequest<OperationResult<int>>;