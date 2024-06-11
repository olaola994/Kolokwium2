using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }
    public DbSet<Backpacks> Backpacks2 { get; set; }
    public DbSet<Items> Items2 { get; set; }
    public DbSet<Characters> Characters2 { get; set; }
    public DbSet<Character_titles> CharacterTitles2 { get; set; }
     public DbSet<Titles> Titles2 { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Backpacks>()
            .HasKey(b => new { b.CharacterId, b.ItemId });
        modelBuilder.Entity<Character_titles>()
            .HasKey(c => new {c.CharacterId , c.TitleId });

        modelBuilder.Entity<Characters>().HasData(new Characters
        {
            Id = 1,
            FirstName = "John",
            LastName = "Yakuza",
            CurrentWeight = 43,
            MaxWeight = 200
        });

        modelBuilder.Entity<Items>().HasData(new Items
            {
                Id = 1,
                Name = "Item1",
                Weight = 10
            },
            new Items
            {
                Id = 2,
                Name = "Item2",
                Weight = 11
            });

        modelBuilder.Entity<Titles>().HasData(new Titles
        {
            Id = 1,
            Name = "Title1"
        });

        modelBuilder.Entity<Character_titles>().HasData(new Character_titles
        {
            CharacterId = 1,
            TitleId = 1,
            AcquiredAt = DateTime.Now
        });

        modelBuilder.Entity<Backpacks>().HasData(new Backpacks
        {
            CharacterId = 1,
            ItemId = 1,
            Amount = 2
        });
    }
    
}