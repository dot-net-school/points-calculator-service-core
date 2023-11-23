using Application.Common.Interfaces;
using Application.DTOs.CustomerService;
using Application.DTOs.MainScore;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class JobExperienceScoreStrategy : IScoreStrategy
{
    private readonly IJobExperienceScoreRepository _jobExperienceScoreRepository;

    public JobExperienceScoreStrategy(IJobExperienceScoreRepository jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
    }

    public async Task<ScoreDataDto> CalculateScore(ReceivedCustomerInfoDto input,CancellationToken cancellationToken=default)
    {
        int jobExperience = input.JobExperience ?? 0;
        if (jobExperience >= 9)
        {
            return ReturnScoreFormat(jobExperience,15);
        }
        //TODO We Have High coupling here, data access duty is repository responsibility but here repository and application layer doing same thing, high coupling!
        var jobExperienceScore = await _jobExperienceScoreRepository.Find(x => x.MinExperience >= jobExperience && x.MaxExperience >= jobExperience)
            .Select(s => s.Score)
            .FirstOrDefaultAsync();
        return ReturnScoreFormat(jobExperience,jobExperienceScore);
    }

    private ScoreDataDto ReturnScoreFormat(int jobExperience, int score)
    {
        ScoreDataDto scoreDataDto = new ScoreDataDto($"Score for jobExperience of {jobExperience}", score);
        return scoreDataDto;
    }
}