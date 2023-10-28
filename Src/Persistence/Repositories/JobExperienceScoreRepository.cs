using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class JobExperienceScoreRepository : IJobExperienceScoreRepository
{
    private readonly ApplicationDbContext _context;
    public JobExperienceScoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(JobExperienceScore jobExperienceScore, CancellationToken cancellationToken = default)
    {
        await _context.JobExperienceScores.AddAsync(jobExperienceScore, cancellationToken);
    }
    public async Task<JobExperienceScore?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.JobExperienceScores.FirstOrDefaultAsync(ls => ls.Id == id, cancellationToken);
    }

    public void Remove(JobExperienceScore jobExperienceScore)
    {
        _context.JobExperienceScores.Remove(jobExperienceScore);
    }

    public void Update(JobExperienceScore jobExperienceScore)
    {
        _context.Entry(jobExperienceScore).State = EntityState.Modified;
        _context.JobExperienceScores.Update(jobExperienceScore);
    }

    public async Task<IReadOnlyList<JobExperienceScore>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _context.JobExperienceScores.AsNoTracking()
                                                       .ToListAsync(cancellationToken);

        return result.AsReadOnly();
    }
    public IQueryable<JobExperienceScore> Find(Expression<Func<JobExperienceScore, bool>> predicate)
    {
        return _context.Set<JobExperienceScore>().Where(predicate);
    }

}
