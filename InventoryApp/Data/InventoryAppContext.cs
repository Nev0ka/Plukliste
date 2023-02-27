using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;

public class InventoryAppContext : DbContext
{
    public InventoryAppContext(DbContextOptions<InventoryAppContext> options)
        : base(options)
    {
    }

    public DbSet<InventoryApp.Models.InventoryContent> InventoryContent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryContent>().ToTable("InventoryContent");
    }
}
