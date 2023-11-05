using Domain.Entities.LanguageScore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public sealed class LanguageCertificationScoreConfig:IEntityTypeConfiguration<LanguageCertificationScore>
{
    public void Configure(EntityTypeBuilder<LanguageCertificationScore> builder)
    {
        builder.HasKey(ls=>ls.Id);
        builder.OwnsOne(ls=>ls.Score);
        builder.HasOne(ls => ls.LanguageCertification)
            .WithMany(lc => lc.LanguageCertificationScores)
            .HasForeignKey(ls => ls.LanguageCertificationId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}