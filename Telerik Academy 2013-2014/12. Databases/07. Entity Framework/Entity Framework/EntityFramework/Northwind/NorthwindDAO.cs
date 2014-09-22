namespace Northwind
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;

    public static class NorthwindDAO
    {
        public static void InsertCustomer(string customerID, string companyName, string contactName, string contactTitle,
            string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            using (var db = new NorthwindEntities())
            {
                if (ExistCustomer(db, customerID))
                {
                    throw new ArgumentException(string.Format("Already exists a customer with ID {0}", customerID));
                }

                Customer newCustomer = new Customer
                {
                    CustomerID = customerID,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }
        }

        public static void ModifyCustomerCompanyName(string customerID, string newCompanyName)
        {
            using (var db = new NorthwindEntities())
            {
                Customer customer = FindCustomerByID(db, customerID);

                customer.CompanyName = newCompanyName;
                db.SaveChanges();
            }
        }

        public static void DeleteCustomerByID(string customerID)
        {
            using (var db = new NorthwindEntities())
            {
                Customer customer = FindCustomerByID(db, customerID);

                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        public static void CustomersByOrderAndShipCity(int year, string shipCountry)
        {
            using (var db = new NorthwindEntities())
            {
                var companyNames = db.Orders
                    .Where(o => o.OrderDate.Value.Year == year && o.ShipCountry == shipCountry)
                    .Join(db.Customers,
                        (o => o.CustomerID), (c => c.CustomerID), (o, c) => c.CompanyName)
                        .Distinct();

                Console.WriteLine("All customers who have orders made in {0} and shipped to {1}:", year, shipCountry);

                foreach (var companyName in companyNames)
                {
                    Console.WriteLine(companyName);
                }
            }
        }

        public static void CustomersByOrderAndShipCitySQL(int year, string shipCountry)
        {
            using (var db = new NorthwindEntities())
            {
                string nativeSqlQuery =
                    "SELECT DISTINCT c.CompanyName " +
                    "FROM Customers c " +
                    "INNER JOIN Orders o " +
                    "ON c.CustomerID = o.CustomerID " +
                    "WHERE YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1};";

                object[] parameters = { year, shipCountry };

                var companyNames = db.Database.SqlQuery<string>(
                    nativeSqlQuery, parameters);

                Console.WriteLine("All customers who have orders made in {0} and shipped to {1} (with SQL Query):",
                    year, shipCountry);

                foreach (var companyName in companyNames)
                {
                    Console.WriteLine(companyName);
                }
            }
        }

        internal static void AllSalesByRegionAndPeriod(string shipRegion, DateTime orderDate, DateTime shippedDate)
        {
            using (var db = new NorthwindEntities())
            {
                var sales = db.Orders
                    .Where(o => o.ShipRegion == shipRegion && o.OrderDate >= orderDate && o.ShippedDate <= shippedDate)
                    .Join(db.Order_Details,
                        (o => o.OrderID), (od => od.OrderID), (o, od) =>
                        new
                        {
                            OrderDate = o.OrderDate,
                            ShippedDate = o.ShippedDate,
                            Quantity = od.Quantity
                        });


                Console.WriteLine("All sales from region {0} and period: {1} - {2}:",
                    shipRegion, orderDate.ToShortDateString(), shippedDate.ToShortDateString());

                foreach (var sale in sales)
                {
                    Console.WriteLine("Order Date: {0}, Shipped Date: {1}, Order Quantity: {2}",
                                        sale.OrderDate.ToString(), sale.ShippedDate.ToString(), sale.Quantity);
                }
            }
        }

        public static void CreateDatabaseTwin()
        {
            using (var db = new NorthwindEntities())
            {
                IObjectContextAdapter context = new NorthwindEntities();
                string cloneNorthwind = context.ObjectContext.CreateDatabaseScript();

                string createNorthwindCloneDB = "CREATE DATABASE NorthwindTwin;";

                SqlConnection dbConForCreatingDB = new SqlConnection(
                    "Server=LOCALHOST; " +
                    "Database=master; " +
                    "Integrated Security=true");

                dbConForCreatingDB.Open();

                using (dbConForCreatingDB)
                {
                    SqlCommand createDB = new SqlCommand(createNorthwindCloneDB, dbConForCreatingDB);
                    createDB.ExecuteNonQuery();
                }

                SqlConnection dbConForCloning = new SqlConnection(
                    "Server=LOCALHOST; " +
                    "Database=NorthwindTwin; " +
                    "Integrated Security=true");

                dbConForCloning.Open();

                using (dbConForCloning)
                {
                    SqlCommand cloneDB = new SqlCommand(cloneNorthwind, dbConForCloning);
                    cloneDB.ExecuteNonQuery();
                }
            }
        }

        public static void ConcurentChanges()
        {
            using (NorthwindEntities northwindEntities1 = new NorthwindEntities())
            {
                using (NorthwindEntities northwindEntities2 = new NorthwindEntities())
                {
                    Customer customerByFirstDataContext = northwindEntities1.Customers.Find("CHOPS");
                    customerByFirstDataContext.Region = "SW";

                    Customer customerBySecondDataContext = northwindEntities2.Customers.Find("CHOPS");
                    customerBySecondDataContext.Region = "SSWW";

                    northwindEntities1.SaveChanges();
                    northwindEntities2.SaveChanges();
                }
            }
        }

        public static void CreateEmployeeInherited()
        {
            Employee extended = new Employee();

            NorthwindEntities context = new NorthwindEntities();

            extended = context.Employees.Find(1);

            foreach (var item in extended.EntityTerritories)
            {
                Console.WriteLine("Teritory description - {0}", item.TerritoryDescription);
            }
        }

        public static void CreateOrder(string customerID, int? employyID, DateTime? orderDate, DateTime? requiredDate,
            DateTime? shippedDate, int? shipVia, decimal? freight, string shipName, string shipAddress, string shipCity,
            string shipRegion, string shipPostalCode, string shipCountry)
        {
            using (var db = new NorthwindEntities())
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (!ExistCustomer(db, customerID))
                        {
                            throw new ArgumentException(string.Format("No existing customer with ID {0}",
                                customerID));
                        }

                        Order newOrder = new Order
                        {
                            CustomerID = customerID,
                            EmployeeID = employyID,
                            OrderDate = orderDate,
                            RequiredDate = requiredDate,
                            ShippedDate = shippedDate,
                            ShipVia = shipVia,
                            Freight = freight,
                            ShipName = shipName,
                            ShipAddress = shipAddress,
                            ShipCity = shipCity,
                            ShipRegion = shipRegion,
                            ShipPostalCode = shipPostalCode,
                            ShipCountry = shipCountry,
                        };

                        db.Orders.Add(newOrder);

                        db.SaveChanges();
                        dbTransaction.Commit();

                        Console.WriteLine("The transaction was successful!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        dbTransaction.Rollback();
                    }
                }
            }
        }

        public static decimal? GetTotalIncomes(string supplierName, DateTime? startDate, DateTime? endDate)
        {
            using (var northwindEntites = new NorthwindEntities())
            {
                var totalIncomeSet = northwindEntites
                    .usp_GetTotalIncome(supplierName, startDate, endDate);

                foreach (var totalIncome in totalIncomeSet)
                {
                    return totalIncome;
                }
            }

            return null;
        }

        private static bool ExistCustomer(NorthwindEntities db, string customerID)
        {
            bool result = db.Customers.Any(c => c.CustomerID == customerID);

            return result;
        }

        private static Customer FindCustomerByID(NorthwindEntities db, string customerID)
        {
            Customer searchedCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == customerID);

            return searchedCustomer;
        }
    }
}