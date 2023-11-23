using Application.Common.Interfaces;
using Application.DTOs.CustomerService;
using Application.DTOs.MainScore;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class AgeScoreStrategy : IScoreStrategy
{
    private readonly IAgeScoreRepository _ageScoreRepository;

    public AgeScoreStrategy( IAgeScoreRepository ageScoreRepository)
    {
        _ageScoreRepository = ageScoreRepository;
    }

    public async Task<ScoreDataDto> CalculateScore(ReceivedCustomerInfoDto input, CancellationToken cancellationToken = default)
    {
        int age = input.Age ?? 0;
        if (age > 45 || age < 18)
        {
            return ReturnScoreFormat(age,0);
        }
        var ageScore = await _ageScoreRepository.Find(x => x.FromAge >= age && x.ToAge >= age)
            .Select(s => s.Score)
            .FirstOrDefaultAsync();
        return ReturnScoreFormat(age,ageScore);
    }
    private ScoreDataDto ReturnScoreFormat(int age,int score)
    {
        ScoreDataDto scoreDataDto = new ScoreDataDto($"Score for age of {age}", score);
        return scoreDataDto;
    }
}