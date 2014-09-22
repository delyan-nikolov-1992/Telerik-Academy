/*
 * 01. Write a program that retrieves from the Northwind sample database in 
 * MS SQL Server the number of  rows in the Categories table.
*/
namespace AllCategories
{
    using System;
    using System.Data.SqlClient;

    public class AllCategories
    {
        private const string SqlConnectionString = "Server=.; Database=Northwind; Integrated Security=true";

        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection(SqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories;", dbCon);

                int categoriesCount = (int)cmdCount.ExecuteScalar();

                Console.WriteLine("Categories count: {0} ", categoriesCount);
            }
        }
    }
}