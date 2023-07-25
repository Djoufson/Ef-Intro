using Ef_Intro.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ef_Intro.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}
