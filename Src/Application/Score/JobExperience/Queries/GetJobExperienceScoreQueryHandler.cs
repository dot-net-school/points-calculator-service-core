using Application.Common.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Score.JobExperience.Queries;

public class GetJobExperienceScoreQueryHandler : IRequestHandler<GetJobExperienceScoreQuery, List<GetJobExperienceScoreDto>>
{
    private readonly IRepository<JobExperienceScore> _jobExperienceScoreRepository;

    public GetJobExperienceScoreQueryHandler(IRepository<JobExperienceScore> jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
    }


    public async Task<List<GetJobExperienceScoreDto>> Handle(GetJobExperienceScoreQuery request, CancellationToken cancellationToken)
    {
        return (await _jobExperienceScoreRepository.GetAll().ToListAsync(cancellationToken)).Adapt<List<GetJobExperienceScoreDto>>();
    }

}