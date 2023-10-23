using MediatR;
using Shared;

namespace Application.Score.MaritalStatus.Commands.UpdateMaritalStatusScore;

public record UpdateMaritalStatusScoreCommand(Guid Id , string MaritalStatus, int Score) : IRequest<OperationResult<string>>;

