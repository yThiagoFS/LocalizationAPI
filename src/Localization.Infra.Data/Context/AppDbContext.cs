using Microsoft.EntityFrameworkCore;

namespace Localization.Infra.Data.Context;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) {}

    public DbSet<Domain.Entities.Localization> Localizations { get; set; }

    public DbSet<Domain.Entities.User> Users { get; set; }

    public DbSet<Domain.Entities.Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}