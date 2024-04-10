using Microsoft.EntityFrameworkCore;

namespace Persistence;

internal sealed class AppDbContext(
    DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
}
