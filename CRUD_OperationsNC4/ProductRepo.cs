using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CRUD_OperationsNC4
{
    public class ProductRepo
    {

        public static string connString;

        public List<Product> GetProducts()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT ProductID, Name, Price, StockLevel FROM products;";
                MySqlDataReader reader = cmd.ExecuteReader();

                var products = new List<Product>();
                while (reader.Read())
                {
                    var row = new Product();
                    row.ProductID = reader.GetInt32("ProductID");
                    row.Name = reader.GetString("Name");
                    row.Price = reader.GetDecimal("Price");
                    row.StockLevel = reader.GetInt32("StockLevel");

                    products.Add(row);
                }
                return products;

            }


        }

        public void CreateProduct(Product p)
        {

            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO products(Name, Price, CategoryID, OnSale, StockLevel) " +
                    "VALUES (@name, @price, @catID, @sale, @stock);";
                cmd.Parameters.AddWithValue("name", p.Name);
                cmd.Parameters.AddWithValue("price", p.Price);
                cmd.Parameters.AddWithValue("catID", p.CategoryID);
                cmd.Parameters.AddWithValue("sale", p.OnSale);
                cmd.Parameters.AddWithValue("stock", p.StockLevel);

                cmd.ExecuteNonQuery();

            }


        }

        public void UpdateProduct(Product p)
        {

            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE products SET StockLevel=@stock WHERE ProductID=@prodID;";
                cmd.Parameters.AddWithValue("stock", p.StockLevel);
                cmd.Parameters.AddWithValue("prodID", p.ProductID);

                cmd.ExecuteNonQuery();

            }

        }

        public void DeleteProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM products WHERE ProductID=@id;";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteName(string name)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM products WHERE Name=@name;";
                cmd.Parameters.AddWithValue("name", name);
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteIdName(int id, string name)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM products WHERE ProductID=@id AND Name=@name;";
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();

            }
        }
    }
}