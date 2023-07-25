using Ef_Intro.Data;
using Ef_Intro.Services;
using Ef_Intro.Utilities;

internal class Program
{
    private static void Main()
    {
        bool exit = false;
        // We instantiate our db context
        using var dbContext = new AppDbContext();
        IProductsService productsService = new ProductsService(dbContext);
        IInputManager inputManager = new InputManager(productsService);

        // We initialize the database
        Database.InitDatabase(dbContext);

        while (!exit)
        {
            int input = Display.Menu();
            exit = !inputManager.Proceed(input);
            Display.ResetConsole();
        }

        // We close the db context
        dbContext.Dispose();
    }
}
