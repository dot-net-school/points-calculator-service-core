using Domain.Entities;
using System.Reflection;
using Domain.Entities.LanguageScore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("base");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<AgeScore> AgeScores { get; set; }
    public DbSet<JobExperienceScore> JobExperienceScores { get; set; }
    public DbSet<LanguageCertification> LanguageCertifications { get; set; }
    public DbSet<LanguageCertificationScore> LanguageScores { get; set; }
    public DbSet<MaritalStatusScore> MaritalStatusScores { get; set; }
    public DbSet<UniversityDegree> UniversityDegrees { get; set; }
}