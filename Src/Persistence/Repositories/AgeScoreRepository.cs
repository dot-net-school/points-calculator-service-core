using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class AgeScoreRepository : IAgeScoreRepository
{
    private readonly ApplicationDbContext _context;

    public AgeScoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AgeScore ageScore, CancellationToken cancellationToken = default)
    {
        await _context.AgeScores.AddAsync(ageScore, cancellationToken);
    }

    public async Task<AgeScore?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.AgeScores.FirstOrDefaultAsync(ls => ls.Id == id, cancellationToken);
    }

    public void Remove(AgeScore ageScore)
    {
        _context.AgeScores.Remove(ageScore);
    }

    public void Update(AgeScore agesScore)
    {
        _context.Entry(agesScore).State = EntityState.Modified;
        _context.AgeScores.Update(agesScore);
    }

    public async Task<IReadOnlyList<AgeScore>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _context.AgeScores.AsNoTracking()
                                             .ToListAsync(cancellationToken);

        return result.AsReadOnly();
    }
}
