//create your ProductType class here
//create your ProductType class here

using System;

namespace BrassAndPoem;

public class ProductType
{
    public string Title { get; set; }
    public int TypeId { get; set; }


    //This is the constructor for ProductTypes
    public ProductType(string title, int typeId)
    {
        Title = title;
        TypeId = typeId;
    }


}