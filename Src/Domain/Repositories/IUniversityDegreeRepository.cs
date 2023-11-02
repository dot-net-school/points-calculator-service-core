using Domain.Entities;

namespace Domain.Repositories;

public interface IUniversityDegreeRepository
{
    public Task AddAsync(UniversityDegree universityDegree, CancellationToken cancellationToken = default);
    public Task<IReadOnlyList<UniversityDegree?>> ListAllAsync( CancellationToken cancellationToken = default);

    public Task<UniversityDegree?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<UniversityDegree?> GetByIdAsyncAsNoTracking(Guid id, CancellationToken cancellationToken = default);

    public void Update(UniversityDegree universityDegree);
    public void Remove(UniversityDegree universityDegree);

}