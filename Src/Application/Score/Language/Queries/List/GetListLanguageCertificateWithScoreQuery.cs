using MediatR;
using Shared;

namespace Application.Score.Language.Queries.List;

public record GetListLanguageCertificateWithScoreQuery()
    :IRequest<OperationResult<List<GetLanguageCertificateWithScoreDto>>>;