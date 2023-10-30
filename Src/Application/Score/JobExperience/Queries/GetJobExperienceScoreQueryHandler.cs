using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Score.JobExperience.Queries;

public class GetJobExperienceScoreQueryHandler : IRequestHandler<GetJobExperienceScoreQuery, List<GetJobExperienceScoreDto>>
{
    private readonly IJobExperienceScoreRepository _jobExperienceScoreRepository;

    public GetJobExperienceScoreQueryHandler(IJobExperienceScoreRepository jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
    }


    public async Task<List<GetJobExperienceScoreDto>> Handle(GetJobExperienceScoreQuery request, CancellationToken cancellationToken)
    {
        return (await _jobExperienceScoreRepository.GetAllAsync(cancellationToken)).Adapt<List<GetJobExperienceScoreDto>>();
    }

}