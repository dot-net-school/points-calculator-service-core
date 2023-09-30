using MediatR;

namespace Application.Score.JobExperienceScore.Queries;

public record GetJobExperienceScoreQuery() : IRequest<List<GetJobExperienceScoreDto>>;

