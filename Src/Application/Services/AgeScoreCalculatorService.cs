using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class AgeScoreCalculatorService : IScoreCalculatorService<int, int>
{
    private readonly IRepository<AgeScore> _repository;

    public AgeScoreCalculatorService(IRepository<AgeScore> repository)
    {
        _repository = repository;
    }

    public async Task<int> CalculateScore(int age, CancellationToken cancellationToken = default)
    {
        if (age > 45 || age < 18)
        {
            return 0;
        }
        var ageScore = await _repository.Find(x => x.FromAge >= age && x.ToAge >= age)
            .Select(s => s.Score)
            .FirstOrDefaultAsync();

        return ageScore;
    }
}