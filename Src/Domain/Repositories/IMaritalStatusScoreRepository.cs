using Domain.Entities;

namespace Domain.Repositories;

public interface IMaritalStatusScoreRepository
{
    void Update(MaritalStatusScore maritalStatusScore);
    Task AddAsync(MaritalStatusScore maritalStatusScore, CancellationToken cancellationToken = default);
    Task<MaritalStatusScore?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Remove(MaritalStatusScore maritalStatusScore);
    Task<IReadOnlyList<MaritalStatusScore>> GetAllAsync(CancellationToken cancellationToken = default);
}
