using Ef_Intro.Entities;

namespace Ef_Intro.Services;

public interface IProductsService
{
    Product Add(Product product);
    Product? Get(int id);
    Product? Update(int id, decimal newPrice);
    bool Delete(int id);
    IReadOnlyList<Product> GetAll();
}