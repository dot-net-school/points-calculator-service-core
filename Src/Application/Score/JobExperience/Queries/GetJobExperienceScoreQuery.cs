using MediatR;

namespace Application.Score.JobExperience.Queries;

public record GetJobExperienceScoreQuery() : IRequest<List<GetJobExperienceScoreDto>>;

