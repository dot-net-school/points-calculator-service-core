using Domain.Entities;
using Domain.Entities.LanguageScore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.UnitOfWork;

public partial class ApplicationUnitOfWork
{
    public DbSet<AgeScore> AgeScores { get; set; }
    public DbSet<JobExperienceScore> JobExperienceScores { get; set; }
    public DbSet<LanguageCertification> LanguageCertifications { get; set; }
    public DbSet<LanguageCertificationScore> LanguageScores { get; set; }
    public DbSet<MaritalStatusScore> MaritalStatusScores { get; set; }
}