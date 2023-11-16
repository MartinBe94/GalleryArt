using Data.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class ArtGalleryContext:DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<SignUp> SignUps => Set<SignUp>();
    public DbSet<Login> Logins => Set<Login>();

    public DbSet<ArtImage> ArtImages => Set<ArtImage>();

    public ArtGalleryContext(DbContextOptions<ArtGalleryContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<SignUp>().HasKey(r => r.Id);
        builder.Entity<Login>().HasKey(l => l.Id);
        builder.Entity<ArtImage>().HasKey(ai => ai.Id);
    }
}
