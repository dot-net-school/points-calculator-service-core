using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class JobExperienceScoreCalculatorService : IScoreCalculatorService<int, int>
{
    private readonly IApplicationDbContext _context;

    public JobExperienceScoreCalculatorService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CalculateScore(int jobExperience)
    {
        if (jobExperience >= 9)
        {
            return 15;
        }

        var jobExperienceScore = await _context.JobExperienceScores
            .Where(x => x.MinExperience >= jobExperience && x.MaxExperience >= jobExperience)
            .Select(s => s.Score)
            .FirstOrDefaultAsync();

        return jobExperienceScore;

    }
}