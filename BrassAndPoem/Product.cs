//create your Product class here
//create your Product class here
using System;
using System.Runtime.CompilerServices;

namespace BrassAndPoem;
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int ProductTypeId { get; set; }


    // This is the constructor for the Product class
    public Product(string name, decimal price, int productTypeId)
    {

        Name = name;
        Price = price;
        ProductTypeId = productTypeId;





    }





}

