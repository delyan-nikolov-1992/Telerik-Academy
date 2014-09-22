/*
 * 04. Write a method that adds a new product in the products table in the Northwind database. 
 * Use a parameterized SQL command.
*/
namespace AddNewProduct
{
    using System;
    using System.Data.SqlClient;

    public class AddNewProduct
    {
        private const string SqlConnectionString = "Server=.; Database=Northwind; Integrated Security=true";

        private SqlConnection dbCon;

        public static void Main()
        {
            AddNewProduct productToBeAdded = new AddNewProduct();

            try
            {
                productToBeAdded.ConnectToDB();

                int newProductId = productToBeAdded.InsertProduct("Bread Dobrudzha", null, null, null, null, 
                    null, null, null, true);

                Console.WriteLine("Inserted new product. " +
                    "ProductID = {0}", newProductId);
            }
            finally
            {
                productToBeAdded.DisconnectFromDB();
            }
        }

        private void ConnectToDB()
        {
            dbCon = new SqlConnection(SqlConnectionString);
            dbCon.Open();
        }

        private void DisconnectFromDB()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }

        private int InsertProduct(string productName, int? supplierID, int? categoryID,
            string quantityPerUnit, decimal? unitPrice, int? unitsInStock, int? unitsOnOrder,
            int? reorderLevel, bool discontinued)
        {
            SqlCommand cmdInsertProject = new SqlCommand(
                "INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, " +
                "UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                "VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, " +
                "@unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", dbCon);

            cmdInsertProject.Parameters.AddWithValue("@productName", productName);
            cmdInsertProject.Parameters.Add(AddPossibleNullObject("@supplierID", supplierID));
            cmdInsertProject.Parameters.Add(AddPossibleNullObject("@categoryID", categoryID));
            cmdInsertProject.Parameters.Add(AddPossibleNullObject("@quantityPerUnit", quantityPerUnit));
            cmdInsertProject.Parameters.Add(AddPossibleNullObject("@unitPrice", unitPrice));
            cmdInsertProject.Parameters.Add(AddPossibleNullObject("@unitsInStock", unitsInStock));
            cmdInsertProject.Parameters.Add(AddPossibleNullObject("@unitsOnOrder", unitsOnOrder));
            cmdInsertProject.Parameters.Add(AddPossibleNullObject("@reorderLevel", reorderLevel));
            cmdInsertProject.Parameters.AddWithValue("@discontinued", (discontinued ? 1 : 0));

            cmdInsertProject.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();

            return insertedRecordId;
        }

        private static SqlParameter AddPossibleNullObject(string parameterName, object parameter)
        {
            SqlParameter sqlParameterSupplierID = new SqlParameter(parameterName, parameter);

            if (parameter == null)
            {
                sqlParameterSupplierID.Value = DBNull.Value;
            }

            return sqlParameterSupplierID;
        }
    }
}