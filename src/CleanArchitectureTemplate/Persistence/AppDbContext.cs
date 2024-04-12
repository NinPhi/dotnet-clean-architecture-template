using Domain.Modules.Samples;

namespace Persistence;

/// <summary>
/// Database context.
/// </summary>
/// <param name="opts">Database context options.</param>
internal sealed class AppDbContext(
    DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    /// <summary>
    /// <see cref="DbSet{TEntity}"/> that can be used to query and save instances of <see cref="Sample"/>.
    /// </summary>
    public DbSet<Sample> Samples => Set<Sample>();
}
