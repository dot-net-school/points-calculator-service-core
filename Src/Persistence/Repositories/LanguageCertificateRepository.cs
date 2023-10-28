using Domain.Entities.LanguageScore;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal sealed class LanguageCertificateRepository : ILanguageCertificateRepository
{
    private readonly ApplicationDbContext _context;

    public LanguageCertificateRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(LanguageCertification languageCertification,
        CancellationToken cancellationToken = default)
    {
        await _context.LanguageCertifications.AddAsync(languageCertification, cancellationToken);
    }

    public async Task<LanguageCertification?> GetByIdWithScoreAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.LanguageCertifications
            .Include(lc => lc.LanguageCertificationScores)
            .FirstOrDefaultAsync(lc => lc.Id == id, cancellationToken);
    }

    public async Task<LanguageCertification?> GetByIdAsNoTrackingWithScoreAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.LanguageCertifications
            .Include(lc => lc.LanguageCertificationScores)
            .AsNoTracking()
            .FirstOrDefaultAsync(lc => lc.Id == id, cancellationToken);
    }

    public async Task<LanguageCertification?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.LanguageCertifications
            .FirstOrDefaultAsync(lc => lc.Id == id, cancellationToken);
    }

    public async Task<LanguageCertification?> GetByIdAsNoTrackingAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.LanguageCertifications
            .AsNoTracking()
            .FirstOrDefaultAsync(lc => lc.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<LanguageCertification>> GetAllWithScoreAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _context.LanguageCertifications
            .Include(lc => lc.LanguageCertificationScores)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return result.AsReadOnly();
    }

    public void Remove(LanguageCertification languageCertification)
    {
        _context.LanguageCertifications.Remove(languageCertification);
    }
}