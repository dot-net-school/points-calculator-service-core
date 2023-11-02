using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Repositories;

public interface IJobExperienceScoreRepository
{
    Task AddAsync(JobExperienceScore jobExperienceScore, CancellationToken cancellationToken = default);
    IQueryable<JobExperienceScore> Find(Expression<Func<JobExperienceScore, bool>> predicate);
    Task<IReadOnlyList<JobExperienceScore>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<JobExperienceScore?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Remove(JobExperienceScore jobExperienceScore);
    void Update(JobExperienceScore jobExperienceScore);
}
