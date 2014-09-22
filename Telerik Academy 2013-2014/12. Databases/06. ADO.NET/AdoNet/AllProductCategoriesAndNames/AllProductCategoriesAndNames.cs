/*
 * 03. Write a program that retrieves from the Northwind database all product categories and 
 * the names of the products in each category. Can you do this with a single SQL query (with table join)? 
*/
namespace AllProductCategoriesAndNames
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class AllProductCategoriesAndNames
    {
        private const string SqlConnectionString = "Server=.; Database=Northwind; Integrated Security=true";

        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection(SqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdAllCategoriesWIthProducts = new SqlCommand(@"
                        SELECT c.CategoryName, p.ProductName
                        FROM Products p
                        INNER JOIN Categories c
                        ON p.CategoryID = c.CategoryID
                        ORDER BY c.CategoryName;", dbCon);

                SqlDataReader reader = cmdAllCategoriesWIthProducts.ExecuteReader();
                StringBuilder result = new StringBuilder();

                using (reader)
                {
                    string oldCategoyName = null;

                    Console.WriteLine("All product categories and the names of the products in each category:");

                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];

                        if (oldCategoyName == null || oldCategoyName != categoryName)
                        {
                            result.AppendLine("\n" + new string('-', 50));
                            result.Append(string.Format("{0} -> {1}", categoryName, productName));
                        }
                        else
                        {
                            result.Append(string.Format(", {0}", productName));
                        }

                        oldCategoyName = categoryName;
                    }
                }

                Console.WriteLine(result.ToString());
            }
        }
    }
}