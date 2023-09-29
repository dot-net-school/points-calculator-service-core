using MediatR;

namespace Application.Score.Queries.GetJobExperienceScore;

public record GetJobExperienceScoreQuery() : IRequest<List<GetJobExperienceScoreDto>>;

