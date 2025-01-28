

using BrassAndPoem;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;


class Program
{
    //create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

    static List<Product> products = new List<Product>()
    {
        new Product("The Raven", 10.99m, 0),
        new Product("The Road Not Taken", 15.99m, 0),
        new Product("Mcbeth", 20.99m, 0),
        new Product("Trumpet", 100.99m, 1),
        new Product("trumbone", 75.99m, 1),
    };


    //create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

    static List<ProductType> productTypes = new List<ProductType>()
    {

    new ProductType("Poem", 0),
    new ProductType("Brass", 1),
    };

    public static void Main()
    {
        MainMenu();

    }

    static void MainMenu()
    {
        //put your greeting here

        Console.Clear();
        string greeting = "welcome to the Brass And Poem Store";
        Console.WriteLine(greeting);
        Console.WriteLine("");
        Console.WriteLine("Option 1: Display All Products");
        Console.WriteLine("Option 2: Delete a Product");
        Console.WriteLine("Option 3: Add a Product");
        Console.WriteLine("Option 4: Update a Product");
        Console.WriteLine("Option 5: Exit Program");
        Console.WriteLine("Please select 1 or 2 or 3 or 4 or 5 to Navigate the Main Menu!");

        string Myoptions;
        Myoptions = Console.ReadLine();

        //implement your loop here

        switch (Myoptions)
        {
            case "1":
                DisplayAllProducts(products, productTypes);
                break;
            case "2":
                DeleteProduct(products, productTypes);
                break;
            case "3":
                AddProduct(products, productTypes);
                break;
            case "4":
                UpdateProduct(products, productTypes);
                break;
            case "5":
                ExitProgram();
                break;
        }

    }

    private static void ExitProgram()
    {

        Console.WriteLine("Thank you for using the Brass and Poem Store.");
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
        Environment.Exit(0);

    }

    private static void UpdateProduct(List<Product> products, List<ProductType> productTypes)
    {

        Console.Clear();
        Console.WriteLine("Update Product");
        Console.WriteLine("");

        Console.WriteLine("Select Product number to Update.");

        List<Product> allproducts = products.FindAll(a => !string.IsNullOrEmpty(a.Name));

        if (allproducts.Count == 0)
        {
            Console.WriteLine("No Product to Update");
            Console.WriteLine("Press Enter to return to MainMenu.");
            Console.ReadLine();
            return;

        }

        foreach (Product product in products)
        {
            Console.WriteLine($"{product.Name},{product.Price}, {productTypes[product.ProductTypeId].Title}");
        }

        int productNumber;
        if (int.TryParse(Console.ReadLine(), out productNumber) && productNumber > 0 && productNumber <= products.Count)
        {
            Product selectedProduct = allproducts[productNumber - 1];

            Console.WriteLine($"You have have selected {selectedProduct.Name}. Details are:");
            Console.WriteLine($"Name: {selectedProduct.Name}");
            Console.WriteLine($"Price: {selectedProduct.Price}");
            Console.WriteLine($"Product Type: {selectedProduct.ProductTypeId}");

            Console.WriteLine("What detail would you like to update?");
            Console.WriteLine("1: Name");
            Console.WriteLine("2: Price");
            Console.WriteLine("3: Product Type");
            string updateChoice = Console.ReadLine();

            switch (updateChoice)
            {
                case "1":
                    Console.WriteLine("Enter new name:  ");
                    selectedProduct.Name = Console.ReadLine();
                    Console.WriteLine($"Product name updated to: {selectedProduct.Name}");
                    break;

                case "2":
                    Console.WriteLine("Enter new price: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                    {
                        selectedProduct.Price = newPrice;
                        Console.WriteLine($"Product price updated to: {selectedProduct.Price}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid price entered.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Enter new product type: ");
                    Console.WriteLine("\n Enter 0 for Poem and 1 for Brass.");
                    if (int.TryParse(Console.ReadLine(), out int newProductTypeId))
                    {
                        selectedProduct.ProductTypeId = newProductTypeId;
                        Console.WriteLine($"Product type updated to: {selectedProduct.ProductTypeId}");



                    }
                    else
                    {
                        Console.WriteLine("Invalid product type entered.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid product selection. Returning to Main Menu.");
                    break;

            }

            Console.WriteLine("Press enter to return to main menu.");
            Console.ReadLine();
            MainMenu();

        }

    }


    // Method to add Product
    private static void AddProduct(List<Product> products, List<ProductType> productTypes)
    {

        Console.Clear();
        Console.WriteLine("Enter new Product Details");

        Console.WriteLine("Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("ProductType: ");
        Console.WriteLine("\n Enter a 0 for Poem or 1 for Brass.");
        int productTypeId = int.Parse(Console.ReadLine());

        Product newProduct = new Product(name, price, productTypeId);

        products.Add(newProduct);

        Console.WriteLine("product has been added");
        Console.WriteLine("Press enter to return to MainMenu.");
        Console.ReadLine();
        MainMenu();

    }



    //Method to display all products
    static void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
    {

        Console.Clear();
        Console.WriteLine("Display all Products");
        int counter = 1;

        foreach (var product in products)
        {
            Console.WriteLine($" {product.Name}, {product.Price}, {productTypes[product.ProductTypeId].Title}");
            Console.ReadLine();

        }
    }

    // Method to delete a product
    static void DeleteProduct(List<Product> products, List<ProductType> productTypes)
    {

        Console.Clear();
        Console.WriteLine("Please select the Product you wish to Delete.");

        //Filter all Products
        List<Product> allproducts = products.FindAll(a => !string.IsNullOrEmpty(a.Name));

        if (allproducts.Count == 0)
        {
            Console.WriteLine("No Product to Delete");
            Console.WriteLine("Press Enter to return to MainMenu.");
            Console.ReadLine();
            return;

        }

        foreach (var product in allproducts)
        {
            Console.WriteLine($"{product.Name} - Price:{product.Price} dollars  {productTypes[product.ProductTypeId].Title}");

            int selectedIndex = 0;
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    Console.WriteLine("Enter the number of the Product to Delete");
                    selectedIndex = int.Parse(Console.ReadLine()) - 1;

                    if (selectedIndex >= 0 && selectedIndex < allproducts.Count)
                    {

                        Product productToRemove = allproducts[selectedIndex];
                        products.Remove(productToRemove);

                        Console.WriteLine($"Successfully deleted {productToRemove}.");
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Index Selected");

                    }
                }
                catch
                {
                    Console.WriteLine("Invaid input");
                }
            }

            Console.WriteLine("Press enter to return to the MainMenu.");
            Console.ReadLine();
            MainMenu();





            // don't move or change this!
            //public partial class Program { }

        }
    }
}





















































































































































