using Ef_Intro.Entities;
using Ef_Intro.Utilities;

namespace Ef_Intro.Services;

public class InputManager : IInputManager
{
    private readonly IProductsService _productsService;

    public InputManager(IProductsService productsService)
    {
        _productsService = productsService;
    }

    public bool Proceed(int input)
    {
        Console.Clear();
        return input switch 
        {
            1 => PrintProducts(),
            2 => AddProduct(),
            3 => UpdateProductPrice(),
            4 => DeleteProduct(),
            _ => Exit()
        };
    }

    private static bool Exit()
    {
        return false;
    }

    private bool AddProduct()
    {
        string name = GetStringInput("Enter Product Name: ");
        decimal price = GetDecimalInput("Enter Price: ");
        int quantity = GetIntInput("Enter Quantity: ");

        if(price == -1 && quantity == -1)
        {
            Display.InvalidInput();
            return false;
        }
        else
        {
            var product = new Product()
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };
            return _productsService.Add(product) is not null;
        }
    }

    private bool DeleteProduct()
    {
        int id = GetIntInput("Enter Product Id: ");
        if(id == -1)
            return false;
        else
            return _productsService.Delete(id);
    }

    private bool UpdateProductPrice()
    {
        int id = GetIntInput("Enter Product Id: ");
        if(id == -1)
            return false;
        else
        {
            decimal price = GetIntInput("Enter Price: ");
            if(price == -1)
                return false;
            else
                return _productsService.Update(id, price) is not null;
        }
    }

    private bool PrintProducts()
    {
        var products = _productsService.GetAll();
        if(products is null)
            return false;
        else
        {
            Display.Products(products);
            return true;
        }
    }

    #region  Helper Methods
    private static string GetStringInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? string.Empty;
    }

    private static int GetIntInput(string message)
    {
        Console.Write(message);
        return int.TryParse(Console.ReadLine(), out var result) ?
            result : -1;
    }

    private static decimal GetDecimalInput(string message)
    {
        Console.Write(message);
        return decimal.TryParse(Console.ReadLine(), out var result) ?
            result : -1;
    }
    #endregion
}
