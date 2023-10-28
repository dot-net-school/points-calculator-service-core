using Domain.Entities;

namespace Domain.Repositories;

public interface IAgeScoreRepository
{
    void Update(AgeScore agesScore);
    Task AddAsync(AgeScore ageScore, CancellationToken cancellationToken = default);
    Task<AgeScore?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Remove(AgeScore ageScore);
    Task<IReadOnlyList<AgeScore>> GetAllAsync(CancellationToken cancellationToken = default);
}
