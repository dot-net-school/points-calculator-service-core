using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
   
    public DbSet<AgeScore> AgeScores { get; set; }
    public DbSet<JobExperienceScore> JobExperienceScores { get; set; }
    public DbSet<MaritalStatusScore> MaritalStatusScores { get; set; }
}
