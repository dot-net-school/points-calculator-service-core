using MediatR;

namespace Application.Score.MaritalStatus.Queries;

public record GetMaritalStatusScoreQuery() : IRequest<IReadOnlyList<GetMaritalStatusScoreDto>>;