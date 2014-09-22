/*
 * 06. Create an Excel file with 2 columns: name and score.
 * 
 * Write a program that reads your MS Excel file through the OLE DB data provider 
 * and displays the name and score row by row.
*/
namespace ReadExcelFile
{
    using System;
    using System.Data.OleDb;

    public class ReadExcelFile
    {
        // if the program throws exception that says you don't have ACE on this machine, the first gyu has a solution:
        // by downloading the first ACE it didn't work, but with the second link it worked
        // http://social.msdn.microsoft.com/Forums/en-US/1d5c04c7-157f-4955-a14b-41d912d50a64/how-to-fix-error-the-microsoftaceoledb120-provider-is-not-registered-on-the-local-machine?forum=vstsdb

        private const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../../Students.xlsx;" +
            "Extended Properties=Excel 12.0;";

        public static void Main()
        {
            OleDbConnection dbCon = new OleDbConnection(ConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                OleDbCommand cmdAllStudents = new OleDbCommand(
                    @"SELECT Name, Score FROM [Students$]", dbCon);

                try
                {
                    OleDbDataReader reader = cmdAllStudents.ExecuteReader();

                    using (reader)
                    {
                        Console.WriteLine("The names and scores of all students:\n");

                        while (reader.Read())
                        {
                            string name = (string)reader["Name"];
                            double score = (double)reader["Score"];

                            Console.WriteLine("{0} - {1}", name, score);
                        }
                    }
                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("SQL Error occured: " + exception);
                }
            }
        }
    }
}