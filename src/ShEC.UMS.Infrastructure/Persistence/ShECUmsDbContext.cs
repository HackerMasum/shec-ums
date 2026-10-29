using Microsoft.EntityFrameworkCore;

namespace ShEC.UMS.Infrastructure.Persistence;

public sealed class ShECUmsDbContext(
    DbContextOptions<ShECUmsDbContext> options)
    : DbContext(options)
{
}
