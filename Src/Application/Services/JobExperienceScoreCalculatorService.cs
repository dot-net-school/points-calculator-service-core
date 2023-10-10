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

    public async Task<int> CalculateScore(int jobExperience)
    {
        if (jobExperience >= 9)
        {
            return 15;
        }

        var jobExperienceScore = await _repository.Find(x => x.MinExperience >= jobExperience && x.MaxExperience >= jobExperience)
            .Select(s => s.Score)
            .FirstOrDefaultAsync();

        return jobExperienceScore;

    }
}