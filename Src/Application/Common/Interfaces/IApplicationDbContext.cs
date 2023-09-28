using Domain.Entities.AgeScoreEntity;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<AgeScore> AgeScores { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
