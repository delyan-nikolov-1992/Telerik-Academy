/*
 * 10. Re-implement the previous task with SQLite embedded DB (see http://sqlite.phxsoftware.com).
*/
namespace BooksSQLite
{
    using System;
    using System.Data.SQLite;

    public class BooksSQLite
    {
        private const string StringConnection = @"Data Source=../../BooksDB.db;Version=3;";

        private SQLiteConnection dbCon;

        public static void Main()
        {
            BooksSQLite books = new BooksSQLite();

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
            dbCon = new SQLiteConnection(StringConnection);
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
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Books;", dbCon);
            SQLiteDataReader reader = command.ExecuteReader();

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
            SQLiteCommand command = new SQLiteCommand(
                string.Format("SELECT * FROM Books WHERE Title = '{0}';", bookName),
                dbCon);
            SQLiteDataReader reader = command.ExecuteReader();

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
            SQLiteCommand cmdInsertBook = new SQLiteCommand(
                "INSERT INTO Books(Title, Author, PublishDate, ISBN) " +
                "VALUES (@title, @author, @publishDate, @ISBN)", dbCon);

            cmdInsertBook.Parameters.AddWithValue("@title", title);
            cmdInsertBook.Parameters.AddWithValue("@author", author);
            cmdInsertBook.Parameters.AddWithValue("@publishDate", publishDate);
            cmdInsertBook.Parameters.AddWithValue("@ISBN", ISBN);

            cmdInsertBook.ExecuteNonQuery();

            Console.WriteLine("Inserted new book.");
        }
    }
}