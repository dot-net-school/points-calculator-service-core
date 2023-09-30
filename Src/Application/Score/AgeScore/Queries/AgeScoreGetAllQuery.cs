using MediatR;

namespace Application.Score.AgeScore.Queries;

public record AgeScoreGetAllQuery() : IRequest<List<AgeScoreDto>>;
