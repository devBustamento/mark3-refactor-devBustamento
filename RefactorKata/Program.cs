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
                var cmd = connection.CreateCommand();//is there a good way to combine this?
                cmd.CommandText = "select * from Products";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                { //can this be inline, or should it be stubbed out like it is?
                    products.Add(new Product {Name = reader["Name"].ToString()} ); //is this to much on the concise side?? 
                }
            }

            Console.WriteLine("Products Loaded!");
            foreach (var Product in products)//loops best practice & should "Product" be "product" due to scope?
            {
                Console.WriteLine(Product.Name);
            }
        }
    }
}