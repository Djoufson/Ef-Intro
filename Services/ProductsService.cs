using Ef_Intro.Data;
using Ef_Intro.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ef_Intro.Services;

public class ProductsService : IProductsService
{
    private readonly AppDbContext _dbContext;

    public ProductsService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Product Add(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        return product;
    }

    public bool Delete(int id)
    {
        int records = _dbContext.Products.Where(p => p.Id == id).ExecuteDelete();
        return records > 0;
    }

    public Product? Get(int id)
    {
        return _dbContext.Products.Find(id);
    }

    public IReadOnlyList<Product> GetAll()
    {
        return _dbContext.Products.ToArray();
    }

    private Product? Update(Product product)
    {
        _dbContext.Products.Update(product);
        _dbContext.SaveChanges();
        return product;
    }

    public Product? Update(int id, decimal newPrice)
    {
        Product? product = Get(id);
        if (product == null)
        {
            return null;
        }
        product.Price = newPrice;
        return Update(product);
    }
}
