using Application.Common.Interfaces;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class JobExperienceScoreCalculatorService : IScoreCalculatorService<int, int>
{
    private readonly IJobExperienceScoreRepository _jobExperienceScoreRepository;

    public JobExperienceScoreCalculatorService(IJobExperienceScoreRepository jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
    }

    public async Task<int> CalculateScore(int jobExperience,CancellationToken cancellationToken=default)
    {
        if (jobExperience >= 9)
        {
            return 15;
        }
        //TODO We Have High coupling here, data access duty is repository responsibility but here repository and application layer doing same thing, high coupling!
        var jobExperienceScore = await _jobExperienceScoreRepository.Find(x => x.MinExperience >= jobExperience && x.MaxExperience >= jobExperience)
            .Select(s => s.Score)
            .FirstOrDefaultAsync();

        return jobExperienceScore;

    }
}