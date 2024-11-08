using DatabaseSample.Core.Contracts;
using DatabaseSample.Core.Models;
using DatabaseSample.Core.Repositories;
using DatabaseSample.Core.Services;
using System;

namespace DatabaseSample;

public class Program
{
    public static void Main(string[] args)
    {
        //Pakeisti localhost\\MSSQLSERVER01 į localhost ir shopping_sample į savo duomenų bazės pavadinimą.
        IShopRepository shopRepository = new ShopRepository("Server=localhost\\MSSQLSERVER01;Database=shopping_sample;Trusted_Connection=True;TrustServerCertificate=true;");
        IShopService shopService = new ShopService(shopRepository);

        foreach(Product p in shopService.GetAllProducts())
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Enter product id: ");
        int Id = int.Parse(Console.ReadLine());

        Product foundProduct = shopService.GetProductById(Id);

        Console.WriteLine($"Product by id {Id} is:");
        Console.WriteLine(foundProduct);

        Console.WriteLine("Enter product name: ");
        string productName = Console.ReadLine();

        Console.WriteLine("Product price: ");
        decimal productPrice = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Select Product category: (Fruit = 0,  Vegetable = 1, HomeAppliances = 2, Sweets = 3, Bakery = 4)");
        ProductCategory productCategory = (ProductCategory)int.Parse(Console.ReadLine());

        Product newProduct = new Product
        {
            ProductName = productName,
            ProductPrice = productPrice,
            Category = productCategory
        };

        shopService.AddProduct(newProduct);

        foreach (Product p in shopService.GetAllProducts())
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Enter product id to delete product: ");
        int idToDelete = int.Parse(Console.ReadLine());
        shopService.RemoveProductById(idToDelete);

        foreach (Product p in shopService.GetAllProducts())
        {
            Console.WriteLine(p);
        }

        /* 
         CREATE TABLE Products(
	ProductId INT IDENTITY PRIMARY KEY,
	ProductName NVARCHAR(30) NOT NULL,
	ProductPrice MONEY NOT NULL,
	Category INT NOT NULL
);

INSERT INTO Products (ProductName, ProductPrice, Category) VALUES ('Sweets Karuna', 12.21, 3)
         */
    }
}