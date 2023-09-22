using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class AgeScoreCalculatorService : IScoreCalculatorService<int, int>
{
    private readonly IApplicationDbContext _dbContext;
    public AgeScoreCalculatorService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CalculateScore(int input)
    {
        if (input > 45 || input < 18)
            return 0;

        var ageScore = await _dbContext.AgeScores
            .Where(x => x.FromAge >= input && x.ToAge >= input)
            .Select(s => s.Score)
            .FirstOrDefaultAsync();

        return ageScore;
    }
}
