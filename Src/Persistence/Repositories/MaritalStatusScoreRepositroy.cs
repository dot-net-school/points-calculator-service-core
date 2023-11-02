using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class MaritalStatusScoreRepositroy : IMaritalStatusScoreRepository
{
    private readonly ApplicationDbContext _context;
    public MaritalStatusScoreRepositroy(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(MaritalStatusScore maritalStatusScore, CancellationToken cancellationToken = default)
    {
        await _context.MaritalStatusScores.AddAsync(maritalStatusScore, cancellationToken);
    }

    public async Task<MaritalStatusScore?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.MaritalStatusScores.FirstOrDefaultAsync(ls => ls.Id == id, cancellationToken);
    }

    public void Remove(MaritalStatusScore maritalStatusScore)
    {
        _context.MaritalStatusScores.Remove(maritalStatusScore);
    }

    public void Update(MaritalStatusScore maritalStatusScore)
    {
        _context.Entry(maritalStatusScore).State = EntityState.Modified;
        _context.MaritalStatusScores.Update(maritalStatusScore);
    }

    public async Task<IReadOnlyList<MaritalStatusScore>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _context.MaritalStatusScores.AsNoTracking()
                                             .ToListAsync(cancellationToken);

        return result.AsReadOnly();
    }
}
