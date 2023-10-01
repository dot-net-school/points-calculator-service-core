using MediatR;

namespace Application.Score.Age.Queries;

public record AgeScoreGetAllQuery() : IRequest<List<AgeScoreDto>>;
