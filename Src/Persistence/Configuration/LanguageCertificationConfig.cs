using Domain.Entities.LanguageScore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public sealed class LanguageCertificationConfig:IEntityTypeConfiguration<LanguageCertification>
{
    public void Configure(EntityTypeBuilder<LanguageCertification> builder)
    {
        builder.HasMany(lc => lc.LanguageCertificationScores)
            .WithOne(ls => ls.LanguageCertification)
            .HasForeignKey(ls => ls.LanguageCertificationId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}