using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;").CreateCommand();
            cmd.CommandText = "select * from Products";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var prod = new Product { name = reader["Name"].ToString() };
                new List<Product>().Add(prod);
            }

            new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;").Dispose();
            Console.WriteLine("Products Loaded!");
            for (int i = 0; i < new List<Product>().Count; i++)
            {
                Console.WriteLine(new List<Product>()[i].name);
            }
        }
    }
}