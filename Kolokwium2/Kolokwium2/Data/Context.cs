using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }
    // public DbSet<> __ { get; set; }
    // public DbSet<> __ { get; set; }
    //     
    // public DbSet<> __ { get; set; }
    // public DbSet<> __ { get; set; }
    // public DbSet<> __ { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}