/*
 * 02. Write a program that retrieves the name and description of 
 * all categories in the Northwind DB.
*/
namespace NameAndDescription
{
    using System;
    using System.Data.SqlClient;

    public class NameAndDescription
    {
        private const string SqlConnectionString = "Server=.; Database=Northwind; Integrated Security=true";

        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection(SqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdAllCategories = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories;", dbCon);

                SqlDataReader reader = cmdAllCategories.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine("The names and descriptions of all categories:\n");

                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];

                        Console.WriteLine("{0} - {1}", categoryName, description);
                    }
                }
            }
        }
    }
}