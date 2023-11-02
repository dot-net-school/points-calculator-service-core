using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public sealed class UniversityDegreeConfig: IEntityTypeConfiguration<UniversityDegree>
{
    public void Configure(EntityTypeBuilder<UniversityDegree> builder)
    {
        builder.HasKey(ud => ud.Id);
        builder.OwnsOne(ud => ud.Score);
    }
}