using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class JobExperienceScoreCalculatorService : IScoreCalculatorService<int, int>
{
    private readonly IRepository<JobExperienceScore> _repository;

    public JobExperienceScoreCalculatorService( IRepository<JobExperienceScore> repository)
    {
        _repository = repository;
    }

    public async Task<int> CalculateScore(int jobExperience,CancellationToken cancellationToken=default)
    {
        if (jobExperience >= 9)
        {
            return 15;
        }
        //TODO We Have High coupling here, data access duty is repository responsibility but here repository and application layer doing same thing, high coupling!
        var jobExperienceScore = await _repository.Find(x => x.MinExperience >= jobExperience && x.MaxExperience >= jobExperience)
            .Select(s => s.Score)
            .FirstOrDefaultAsync();

        return jobExperienceScore;

    }
}