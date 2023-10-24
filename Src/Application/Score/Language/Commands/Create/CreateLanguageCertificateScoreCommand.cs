using Application.DTOs;
using MediatR;
using Shared;

namespace Application.Score.Language.Commands.Create;


public record CreateLanguageCertificateScoreCommand(byte Score, string? Mark,bool? IsActive, string LanguageCertificationId)
    :IRequest<OperationResult<int>>;
