using Domain.Entities.AgeScoreEntity;
using MediatR;

namespace Application.Score.Queries.GetAllAgeScore;

public record AgeScoreGetAllQuery() : IRequest<List<AgeScore>>;
