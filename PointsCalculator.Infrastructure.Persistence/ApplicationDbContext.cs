using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<AgeScore> AgeScores { get; set; }

    }
}
