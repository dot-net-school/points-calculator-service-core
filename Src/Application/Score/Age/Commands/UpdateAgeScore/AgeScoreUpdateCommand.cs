using MediatR;
using Shared;

namespace Application.Score.Age.Commands.UpdateAgeScore;

public record AgeScoreUpdateCommand(Guid Id, int FromAge, int ToAge, int Score) : IRequest<OperationResult<int>>;
