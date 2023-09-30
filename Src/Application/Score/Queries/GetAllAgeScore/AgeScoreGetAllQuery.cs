using MediatR;

namespace Application.Score.Queries.GetAllAgeScore;

public record AgeScoreGetAllQuery() : IRequest<List<AgeScoreDto>>;
