using Ef_Intro.Data;
using Ef_Intro.Entities;

namespace Ef_Intro.Utilities;

public static class Display
{
    public static void Print(string message)
    {
        Console.WriteLine(message);
    }

    public static void Products(IEnumerable<Product> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine("Id: " + product.Id);
            Console.WriteLine("Name: " + product.Name);
            Console.WriteLine("Price: " + product.Price);
            Console.WriteLine("Quantity: " + product.Quantity);
            Console.WriteLine("===============================");
        }
    }

    public static int Menu()
    {
        Console.WriteLine("1. Print products");
        Console.WriteLine("2. Add product");
        Console.WriteLine("3. Update product price");
        Console.WriteLine("4. Delete product");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");

        return int.TryParse(Console.ReadLine(), out int choice) ?
            choice : -1;
    }

    public static void ResetConsole()
    {
        Console.WriteLine("\nPress any key to continue . . .");
        Console.ReadKey();
        Console.Clear();
    }

    internal static void InvalidInput()
    {
        Console.WriteLine("The input you submitted is not in a valid format");
        Console.WriteLine("\nPress any key to continue . . .");
        Console.ReadKey();
        Console.Clear();
    }
}
