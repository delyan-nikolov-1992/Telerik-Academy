namespace ATM
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public static class TestATM
    {
        private const string ConnectionString = "Server=.;" +
            " Database=ATM; Integrated Security=true";

        private const string CardPINToSearch = "1212";
        private const string CardNumberToSearch = "1111111111";
        private const decimal MoneyToWithdraw = 200;

        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection(ConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                SqlTransaction trans =
                    dbCon.BeginTransaction(IsolationLevel.RepeatableRead);
                Console.WriteLine("Transaction started.");

                SqlCommand cmd = dbCon.CreateCommand();
                cmd.Transaction = trans;

                try
                {
                    if (IsValidOperation(cmd))
                    {
                        WithdrawMoney(cmd);
                        SaveHistory(cmd);
                    }

                    trans.Commit();
                    Console.WriteLine("Transaction comitted.");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Exception occured: {0}", e.Message);
                    trans.Rollback();
                    Console.WriteLine("Transaction cancelled.");
                }
            }
        }

        public static bool IsValidOperation(SqlCommand cmd)
        {
            if (CardPINToSearch == null)
            {
                throw new ArgumentNullException("The card PIN should not be null!");
            }

            if (CardNumberToSearch == null)
            {
                throw new ArgumentNullException("The card number should not be null!");
            }

            if (CardPINToSearch.Length != 4)
            {
                throw new ArgumentOutOfRangeException("The card PIN should be exact 4 chars long!");
            }

            if (CardNumberToSearch.Length != 10)
            {
                throw new ArgumentNullException("The card number should be exact 10 chars long!");
            }

            cmd.CommandText = string.Format(
                "SELECT CardCash " +
                "FROM CardAccounts " +
                "WHERE CardPIN = {0} AND CardNumber = {1};", CardPINToSearch, CardNumberToSearch);

            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    decimal cardCash = (decimal)reader["CardCash"];

                    if (cardCash < MoneyToWithdraw)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void WithdrawMoney(SqlCommand cmd)
        {
            cmd.CommandText = @"
                        UPDATE CardAccounts
                        SET CardCash -= @cardCash
                        WHERE CardPIN = @cardPIN AND CardNumber = @cardNumber;";

            cmd.Parameters.AddWithValue("@cardCash", MoneyToWithdraw);
            cmd.Parameters.AddWithValue("@cardPIN", CardPINToSearch);
            cmd.Parameters.AddWithValue("@cardNumber", CardNumberToSearch);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Updated the card cash!");
        }

        public static void SaveHistory(SqlCommand cmd)
        {
            cmd.CommandText = @"
                        INSERT INTO TransactionsHistory
                        (CardNumber, TransactionDate, Ammount)
                        Values (@withdrawedCardCash, @date, @withdrawedCardNumber);";

            cmd.Parameters.AddWithValue("@withdrawedCardCash", MoneyToWithdraw);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@withdrawedCardNumber", CardNumberToSearch);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Inserted new transaction log!");
        }
    }
}