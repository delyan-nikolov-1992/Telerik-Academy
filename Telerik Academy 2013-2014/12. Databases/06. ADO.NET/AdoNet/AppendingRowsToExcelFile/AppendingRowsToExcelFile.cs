/*
 * 07. Implement appending new rows to the Excel file.
*/
namespace AppendingRowsToExcelFile
{
    using System;
    using System.Data.OleDb;

    public class AppendingRowsToExcelFile
    {
        // if the program throws exception that says you don't have ACE on this machine, the first gyu has a solution:
        // by downloading the first ACE it didn't work, but with the second link it worked
        // http://social.msdn.microsoft.com/Forums/en-US/1d5c04c7-157f-4955-a14b-41d912d50a64/how-to-fix-error-the-microsoftaceoledb120-provider-is-not-registered-on-the-local-machine?forum=vstsdb

        private const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../../Students.xlsx;" +
            "Extended Properties=Excel 12.0;";

        private OleDbConnection dbCon;

        public static void Main()
        {
            AppendingRowsToExcelFile studentToBeAdded = new AppendingRowsToExcelFile();

            try
            {
                studentToBeAdded.ConnectToDB();
                studentToBeAdded.InsertStudent("Grigor Dimitrov", 23);

                Console.WriteLine("Inserted new student.");
            }
            finally
            {
                studentToBeAdded.DisconnectFromDB();
            }
        }

        private void ConnectToDB()
        {
            dbCon = new OleDbConnection(ConnectionString);
            dbCon.Open();
        }

        private void DisconnectFromDB()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }

        private void InsertStudent(string name, double score)
        {
            OleDbCommand cmdInsertStudent = new OleDbCommand(
                "INSERT INTO [Students$](Name, Score)" +
                "VALUES (@name, @score)", dbCon);

            cmdInsertStudent.Parameters.AddWithValue("@name", name);
            cmdInsertStudent.Parameters.AddWithValue("@score", score);

            cmdInsertStudent.ExecuteNonQuery();
        }
    }
}