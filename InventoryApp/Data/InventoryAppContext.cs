using InventoryApp.Models;
using InventoryApp.Pages.Pluklist;
using Microsoft.EntityFrameworkCore;

public class InventoryAppContext : DbContext
{
    public InventoryAppContext(DbContextOptions<InventoryAppContext> options)
        : base(options)
    {
    }

    public DbSet<InventoryContent> InventoryContent { get; set; }
    public DbSet<PluklistContent> PluklistContent { get; set; }
    public DbSet<Item> Item { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryContent>().ToTable("InventoryContent");
        modelBuilder.Entity<PluklistContent>().ToTable("PluklistContent");
        modelBuilder.Entity<Item>().ToTable("Item");
    }
}
