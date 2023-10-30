using MediatR;
using Shared;

namespace Application.Score.MaritalStatus.Commands.CreateMaritalStatusScore;

public record CreateMaritalStatusScoreCommand(string MaritalStatus, int Score) : IRequest<OperationResult<int>>;
