using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.CreateJobExperienceScore;

public record CreateJobExperienceScoreCommand(int MinExperience, int MaxExperience, int Score) : IRequest<OperationResult<int>>;