using Microsoft.EntityFrameworkCore;
using ShEC.UMS.Domain.Students;
using ShEC.UMS.Infrastructure.Persistence.Configurations;

namespace ShEC.UMS.Infrastructure.Persistence;

public sealed class ShECUmsDbContext(
    DbContextOptions<ShECUmsDbContext> options)
    : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new StudentConfiguration());
    }
}
