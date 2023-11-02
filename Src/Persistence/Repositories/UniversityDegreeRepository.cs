using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public sealed class UniversityDegreeRepository : IUniversityDegreeRepository
{
    private readonly ApplicationDbContext _context;

    public UniversityDegreeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UniversityDegree universityDegree, CancellationToken cancellationToken = default)
    {
        await _context.UniversityDegrees.AddAsync(universityDegree, cancellationToken);
    }

    public async Task<IReadOnlyList<UniversityDegree?>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _context.UniversityDegrees.ToListAsync(cancellationToken);
        return result.AsReadOnly();
    }

    public async Task<UniversityDegree?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.UniversityDegrees.FirstOrDefaultAsync(ud => ud.Id == id, cancellationToken);
    }

    public async Task<UniversityDegree?> GetByIdAsyncAsNoTracking(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.UniversityDegrees.AsNoTracking()
            .FirstOrDefaultAsync(ud => ud.Id == id, cancellationToken);
    }

    public void Update(UniversityDegree universityDegree)
    {
        _context.Entry(universityDegree).State = EntityState.Modified;
        _context.UniversityDegrees.Update(universityDegree);
    }

    public void Remove(UniversityDegree universityDegree)
    {
        _context.UniversityDegrees.Remove(universityDegree);
    }
}