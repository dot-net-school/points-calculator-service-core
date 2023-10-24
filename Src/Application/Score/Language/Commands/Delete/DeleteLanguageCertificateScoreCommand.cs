using MediatR;
using Shared;

namespace Application.Score.Language.Commands.Delete;

public record DeleteLanguageCertificateScoreCommand(string? Id):IRequest<OperationResult<int>>;