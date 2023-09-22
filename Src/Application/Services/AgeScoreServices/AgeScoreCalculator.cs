using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AgeScoreServices;

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
        AgeScore? ageScore = await _dbContext.AgeScores.FirstOrDefaultAsync(x => x.FromAge >= age && x.ToAge >= age);
        return ageScore is null ? 0 : ageScore.Score;
    }
}
