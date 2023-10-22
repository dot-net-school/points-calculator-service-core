using MediatR;
using Shared;

namespace Application.Score.Language.Queries.Single;

public record GetSingleLanguageCertificateWithScoreQuery(string? Id) : IRequest<OperationResult<GetLanguageCertificateWithScoreDto>>;