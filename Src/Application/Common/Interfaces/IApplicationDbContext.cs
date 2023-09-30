﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<AgeScore> AgeScores { get; set; }
    public DbSet<JobExperienceScore> JobExperienceScores { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
