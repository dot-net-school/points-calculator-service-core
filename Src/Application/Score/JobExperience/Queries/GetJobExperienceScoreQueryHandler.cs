using Application.Common.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Score.JobExperience.Queries;

public class GetJobExperienceScoreQueryHandler : IRequestHandler<GetJobExperienceScoreQuery, List<GetJobExperienceScoreDto>>
{
    private readonly IRepository<JobExperienceScore> _repository;

    public GetJobExperienceScoreQueryHandler(IRepository<JobExperienceScore> repository)
    {
        _repository = repository;
    }


    public async Task<List<GetJobExperienceScoreDto>> Handle(GetJobExperienceScoreQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.GetAll().ToListAsync(cancellationToken)).Adapt<List<GetJobExperienceScoreDto>>();
    }

}