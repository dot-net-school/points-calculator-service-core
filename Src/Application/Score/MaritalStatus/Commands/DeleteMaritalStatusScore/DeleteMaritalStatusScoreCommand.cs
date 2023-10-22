using MediatR;
using Shared;

namespace Application.Score.MaritalStatus.Commands.DeleteMaritalStatusScore;

public record DeleteMaritalStatusScoreCommand(Guid Id) : IRequest<OperationResult<string>>;


