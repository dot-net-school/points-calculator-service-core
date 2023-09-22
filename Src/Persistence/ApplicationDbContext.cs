using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PointCalculator;Integrated Security=True; Encrypt=false");
    }
    public DbSet<AgeScore> AgeScores { get; set; }
}
