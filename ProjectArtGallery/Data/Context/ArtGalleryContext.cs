using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class ArtGalleryContext:DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Registration> Registrations => Set<Registration>();
    public DbSet<Login> Logins => Set<Login>();

    public ArtGalleryContext(DbContextOptions<ArtGalleryContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<Registration>().HasKey(r => r.Id);
        builder.Entity<Login>().HasKey(l => l.Id);
    }
}
