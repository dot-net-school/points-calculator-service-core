using Application.DTOs;
using MediatR;
using Shared;

namespace Application.Score.Language.Commands.Update;

public record UpdateLanguageCertificateScoreCommand(string? Id,byte Score, string? Mark,bool? IsActive, string? LanguageCertificationId)
    :IRequest<OperationResult<int>>;