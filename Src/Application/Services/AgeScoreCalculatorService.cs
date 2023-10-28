using Application.Common.Interfaces;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class AgeScoreCalculatorService : IScoreCalculatorService<int, int>
{
    private readonly IAgeScoreRepository _ageScoreRepository;

    public AgeScoreCalculatorService( IAgeScoreRepository ageScoreRepository)
    {
        _ageScoreRepository = ageScoreRepository;
    }

    public async Task<int> CalculateScore(int age, CancellationToken cancellationToken = default)
    {
        if (age > 45 || age < 18)
        {
            return 0;
        }
        var ageScore = await _ageScoreRepository.Find(x => x.FromAge >= age && x.ToAge >= age)
            .Select(s => s.Score)
            .FirstOrDefaultAsync();

        return ageScore;
    }
}