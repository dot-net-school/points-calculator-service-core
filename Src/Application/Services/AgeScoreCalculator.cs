using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class AgeScoreCalculator
{
    private readonly IApplicationDbContext _dbContext;
    public AgeScoreCalculator(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> GetAgeScore(int age)
    {
        if (age > 45 || age < 18)
            return 0;

        var ageScore = await _dbContext.AgeScores
            .Where(x => x.FromAge >= age && x.ToAge >= age)
            .Select(s => s.Score)
            .FirstOrDefaultAsync();

        return ageScore;
    }
}
