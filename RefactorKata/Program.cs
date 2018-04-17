using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            using (var connection = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"))
            { //usingusingusing
                var cmd = connection.CreateCommand();
                cmd.CommandText = "select * from Products";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                { products.Add(new Product { Name = reader["Name"].ToString() }); }
            }

            Console.WriteLine("Products Loaded!");
            foreach (var Product in products)
            { Console.WriteLine(Product.Name); }
        }
    }
}