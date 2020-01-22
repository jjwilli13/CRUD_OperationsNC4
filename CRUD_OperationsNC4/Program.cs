using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CRUD_OperationsNC4
{
    class Program
    {
        static void Main(string[] args)
        {

            
            string defaultKey = File.ReadAllText("appsettings.Debug.JSON");
            JObject jObject = JObject.Parse(defaultKey);
            JToken token = jObject["DefaultConnection"];
            string connectionString = token.ToString();
            ProductRepo.connString = connectionString;
            



            ProductRepo repo = new ProductRepo();

            //Create Products
            //Console.WriteLine("Creating Product......");
            //var newProduct = new Product { Name = "Jack Hughes Product", Price = 19.99M, CategoryID = 2, OnSale = 0 };
            //repo.CreateProduct(newProduct);
            //Console.WriteLine("Product Created!");

            //Update Product
            //Console.WriteLine("Updating Product....");
            //var newInfo = new Product { StockLevel = 27, ProductID = 944 };
            //repo.UpdateProduct(newInfo);
            //Console.WriteLine("Your Product has updated!");


            //Delete Product
            //Console.WriteLine("Deleting Product...");
            //repo.DeleteIdName(946, "HAYS Product");
            //repo.DeleteName("Jays Product");
            //repo.DeleteProduct(947);



            //Read Products
            List<Product> products = repo.GetProducts();
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID}  {prod.Name} -------- ${prod.Price}-----You have {prod.StockLevel} of these items.");

            }



        }
    }
}
