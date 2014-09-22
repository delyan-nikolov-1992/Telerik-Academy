/*
 * 09. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + 
 * MySQL Workbench GUI administration tool. Create a MySQL database to store Books 
 * (title, author, publish date and ISBN). Write methods for listing all books, 
 * finding a book by name and adding a book.
*/
namespace Books
{
    using System;
    using MySql.Data.MySqlClient;

    public class Books
    {
        private const string StringConnection = "Server=localhost;Database=BooksDB;Uid=root;Pwd=";

        private MySqlConnection dbCon;

        public static void Main()
        {
            Books books = new Books();

            try
            {
                books.ConnectToDB();

                Console.WriteLine(new string('-', 50));
                books.ListAllBooks();
                Console.WriteLine(new string('-', 50));
                books.PrintBook("The lions");
                Console.WriteLine(new string('-', 50));
                books.AddBook("Harry Potter", "J.K.Rowling", new DateTime(2003, 11, 01), "0000301234561");
            }
            finally
            {
                books.DisconnectFromDB();
            }
        }

        private void ConnectToDB()
        {
            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();

            string connectionStr = StringConnection + pass + ";";

            dbCon = new MySqlConnection(connectionStr);
            dbCon.Open();
        }

        private void DisconnectFromDB()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }

        private void ListAllBooks()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM Books;", dbCon);
            MySqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("All books:");

                while (reader.Read())
                {
                    string title = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    string isbn = (string)reader["ISBN"];

                    Console.WriteLine("\nTitle: {0}; Author: {1}; Publish date: {2}; ISBN: {3}",
                        title, author, publishDate.ToShortDateString(), isbn);
                }
            }
        }

        private void PrintBook(string bookName)
        {
            MySqlCommand command = new MySqlCommand(
                string.Format("SELECT * FROM Books WHERE Title = '{0}';", bookName),
                dbCon);
            MySqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("Books with name \"{0}\":", bookName);

                while (reader.Read())
                {
                    string title = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    string isbn = (string)reader["ISBN"];

                    Console.WriteLine("Title: {0}; Author: {1}; Publish date: {2}; ISBN: {3}",
                        title, author, publishDate.ToShortDateString(), isbn);
                }
            }
        }

        private void AddBook(string title, string author, DateTime publishDate, string ISBN)
        {
            MySqlCommand cmdInsertBook = new MySqlCommand(
                "INSERT INTO Books(Title, Author, PublishDate, ISBN) " +
                "VALUES (@title, @author, @publishDate, @ISBN)", dbCon);

            cmdInsertBook.Parameters.AddWithValue("@title", title);
            cmdInsertBook.Parameters.AddWithValue("@author", author);
            cmdInsertBook.Parameters.AddWithValue("@publishDate", publishDate);
            cmdInsertBook.Parameters.AddWithValue("@ISBN", ISBN);

            cmdInsertBook.ExecuteNonQuery();

            MySqlCommand cmdSelectIdentity = new MySqlCommand("SELECT @@Identity", dbCon);
            cmdSelectIdentity.ExecuteScalar();

            Console.WriteLine("Inserted new book.");
        }
    }
}