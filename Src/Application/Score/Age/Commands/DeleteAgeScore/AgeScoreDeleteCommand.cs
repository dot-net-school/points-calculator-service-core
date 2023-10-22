using MediatR;
using Shared;

namespace Application.Score.Age.Commands.DeleteAgeScore;

public record AgeScoreDeleteCommand(Guid Id) : IRequest<OperationResult<int>>;
