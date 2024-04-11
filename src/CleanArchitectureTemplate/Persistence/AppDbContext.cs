﻿using Domain.Modules.Samples;

namespace Persistence;

internal sealed class AppDbContext(
    DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<Sample> Samples => Set<Sample>();
}
