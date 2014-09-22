namespace Northwind
{
    using System;

    public class Test
    {
        public static void Main()
        {
            try
            {
                // 01. Task: NorthwindDB.edmx

                // 02. Task
                NorthwindDAO.InsertCustomer("TELEA", "Telerik", "Svetlin Nakov", "Education", "ul. Aleksandar Malinov 31",
                    "Sofia", "SF", "2010", "Bulgaria", "0888121413", "01234567");
                NorthwindDAO.ModifyCustomerCompanyName("TELEA", "Telerik AD");
                NorthwindDAO.DeleteCustomerByID("TELEA");

                // 03. Task
                NorthwindDAO.CustomersByOrderAndShipCity(1997, "Canada");
                Console.WriteLine();

                // 04. Task
                NorthwindDAO.CustomersByOrderAndShipCitySQL(1997, "Canada");
                Console.WriteLine();

                // 05. Task
                NorthwindDAO.AllSalesByRegionAndPeriod("RJ", new DateTime(1996, 02, 02), new DateTime(2000, 04, 04));
                Console.WriteLine();

                // 06. Task
                NorthwindDAO.CreateDatabaseTwin();

                // 07. Task
                NorthwindDAO.ConcurentChanges();

                // 08. Task
                NorthwindDAO.CreateEmployeeInherited();

                // 09. Task
                NorthwindDAO.CreateOrder("VINET", 4, new DateTime(1997, 05, 06), new DateTime(1998, 05, 06), null,
                    2, 18.44m, "Ernst Handel", "Kirchgasse 6", "Graz", null, "8010", "Austria");
                Console.WriteLine();

                // 10. Task
                var totalIncome = NorthwindDAO.GetTotalIncomes("Tokyo Traders", 
                    new DateTime(1995, 1, 1), new DateTime(1998, 1, 1));
                Console.WriteLine("TotalIncomes: {0}", totalIncome);
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}