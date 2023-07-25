using Ef_Intro.Data;
namespace Ef_Intro.Utilities;

public static class Database
{
    public static void InitDatabase(AppDbContext dbContext)
    {
        bool isEmpty = dbContext.Products.Any();
        if (!isEmpty)
        {
            dbContext.Products.AddRange(
                new() { Name = "Laptop", Price = 1000, Quantity = 50 },
                new() { Name = "Mouse", Price = 50, Quantity = 25 },
                new() { Name = "Keyboard", Price = 100, Quantity = 10 }
            );

            dbContext.SaveChanges();
        }
    }
}
