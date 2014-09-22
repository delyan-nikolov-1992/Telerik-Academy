/*
 * 08. Write a program that reads a string from the console and finds all products that 
 * contain this string. Ensure you handle correctly characters like ', %, ", \ and _.
*/
namespace AllProductsWithString
{
    using System;
    using System.Data.SqlClient;

    public class AllProductsWithString
    {
        private const string SqlConnectionString = "Server=.; Database=Northwind; Integrated Security=true";
        private static string[] stringsToEscape = { "%", "\"", @"\", "_" };

        public static void Main()
        {
            Console.Write("The string to be searched for: ");
            string originalSubstr = Console.ReadLine();

            string escapedSubstr = originalSubstr.Replace("'", "''");

            foreach (var character in stringsToEscape)
            {
                escapedSubstr = escapedSubstr.Replace(character, string.Format("[{0}]", character));
            }

            SqlConnection dbCon = new SqlConnection(SqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdAllProductNames = new SqlCommand(
                    string.Format("SELECT ProductName FROM Products WHERE ProductName LIKE '%{0}%';", escapedSubstr), 
                    dbCon);

                SqlDataReader reader = cmdAllProductNames.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine("The names of all products that contain \"{0}\":\n", originalSubstr);

                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];

                        Console.WriteLine("{0}", productName);
                    }
                }
            }
        }
    }
}