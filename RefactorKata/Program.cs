using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>();

            using (var connection = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "select * from Products";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add( new Product { Name = reader["Name"].ToString() } );
                }
            }

            Console.WriteLine("Products Loaded!");
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}