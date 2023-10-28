using Domain.Entities;

namespace Domain.Repositories;

public interface IJobExperienceScoreRepository
{
    Task AddAsync(JobExperienceScore jobExperienceScore, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<JobExperienceScore>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<JobExperienceScore?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Remove(JobExperienceScore jobExperienceScore);
    void Update(JobExperienceScore jobExperienceScore);
}
