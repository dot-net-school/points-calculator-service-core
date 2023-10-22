using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Domain.Entities.LanguageScore;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal sealed class LanguageScoreRepository : ILanguageScoreRepository
{
    private readonly ApplicationDbContext _context;

    public LanguageScoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(LanguageCertificationScore languageScore, CancellationToken cancellationToken = default)
    {
        await _context.LanguageScores.AddAsync(languageScore, cancellationToken);
    }

    public async Task<LanguageCertificationScore?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.LanguageScores
            .AsNoTracking()
            .FirstOrDefaultAsync(ls => ls.Id == id, cancellationToken);
    }
    
    public async Task<LanguageCertificationScore?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.LanguageScores
            .FirstOrDefaultAsync(ls => ls.Id == id, cancellationToken);
    }

    public void Remove(LanguageCertificationScore languageCertificationScore)
    {
        _context.LanguageScores.Remove(languageCertificationScore);
    }

    public async Task<ReadOnlyCollection<LanguageCertificationScore>> GetAllScoresWithCertification(
        CancellationToken cancellationToken = default)
    {
        var result = await  _context.LanguageScores
            .Include(lc => lc.LanguageCertification)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        return result.AsReadOnly();

    }
}