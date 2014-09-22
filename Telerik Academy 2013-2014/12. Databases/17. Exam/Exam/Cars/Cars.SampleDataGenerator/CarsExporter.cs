namespace Cars.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using Cars.Data;
    using Cars.Models;

    public class CarsExporter
    {
        private CarsDbContext db;

        public CarsExporter(CarsDbContext db)
        {
            this.db = db;
        }

        public void ExportData(string pathToXmlQueries, string pathToXmlResultFiles)
        {
            var xmlQueries = XElement.Load(pathToXmlQueries).Elements();

            foreach (var xmlQuery in xmlQueries)
            {
                var cars = this.db.Cars.AsQueryable();
                var outputFileName = xmlQuery.Attribute("OutputFileName").Value;
                var resultCars = new List<Car>();

                if (xmlQuery.Elements("WhereClauses").Any())
                {
                    var xmlWhereQueries = xmlQuery.Element("WhereClauses");

                    if (xmlWhereQueries.Elements("WhereClause").Any())
                    {
                        var xmlAllWhereQueries = xmlWhereQueries.Elements("WhereClause");

                        foreach (var xmlWhereQuery in xmlAllWhereQueries)
                        {
                            string wherePropertyName = xmlWhereQuery.Attribute("PropertyName").Value;
                            string whereTypeName = xmlWhereQuery.Attribute("Type").Value;
                            var whereValue = xmlWhereQuery.Value;
                            int whereValueAsInt = 0;
                            decimal whereValueAsDecimal = 0;

                            if (whereTypeName == "Equals")
                            {
                                switch (wherePropertyName)
                                {
                                    case "Id":
                                        whereValueAsInt = int.Parse(whereValue);
                                        cars = cars.Where(c => c.Id == whereValueAsInt);
                                        break;
                                    case "Year":
                                        whereValueAsInt = int.Parse(whereValue);
                                        cars = cars.Where(c => c.Year == whereValueAsInt);
                                        break;
                                    case "Price":
                                        whereValueAsDecimal = decimal.Parse(whereValue);
                                        cars = cars.Where(c => c.Price == whereValueAsDecimal);
                                        break;
                                    case "Model":
                                        cars = cars.Where(c => c.Model == whereValue);
                                        break;
                                    case "Manufacturer":
                                        cars = cars.Where(c => c.Manufacturer.Name == whereValue);
                                        break;
                                    case "Dealer":
                                        cars = cars.Where(c => c.Dealer.Name == whereValue);
                                        break;
                                }
                            }
                            else if (whereTypeName == "GreaterThan")
                            {
                                switch (wherePropertyName)
                                {
                                    case "Id":
                                        whereValueAsInt = int.Parse(whereValue);
                                        cars = cars.Where(c => c.Id > whereValueAsInt);
                                        break;
                                    case "Year":
                                        whereValueAsInt = int.Parse(whereValue);
                                        cars = cars.Where(c => c.Year > whereValueAsInt);
                                        break;
                                    case "Price":
                                        whereValueAsDecimal = decimal.Parse(whereValue);
                                        cars = cars.Where(c => c.Price > whereValueAsDecimal);
                                        break;
                                }
                            }
                            else if (whereTypeName == "LessThan")
                            {
                                switch (wherePropertyName)
                                {
                                    case "Id":
                                        whereValueAsInt = int.Parse(whereValue);
                                        cars = cars.Where(c => c.Id < whereValueAsInt);
                                        break;
                                    case "Year":
                                        whereValueAsInt = int.Parse(whereValue);
                                        cars = cars.Where(c => c.Year < whereValueAsInt);
                                        break;
                                    case "Price":
                                        whereValueAsDecimal = decimal.Parse(whereValue);
                                        cars = cars.Where(c => c.Price < whereValueAsDecimal);
                                        break;
                                }
                            }
                            else if (whereTypeName == "Contains")
                            {
                                switch (wherePropertyName)
                                {
                                    case "Model":
                                        cars = cars.Where(c => c.Model.Contains(whereValue));
                                        break;
                                    case "Manufacturer":
                                        cars = cars.Where(c => c.Manufacturer.Name.Contains(whereValue));
                                        break;
                                    case "Dealer":
                                        cars = cars.Where(c => c.Dealer.Name.Contains(whereValue));
                                        break;
                                }
                            }
                        }
                    }
                }

                if (xmlQuery.Elements("OrderBy").Any())
                {
                    string orderField = xmlQuery.Element("OrderBy").Value;

                    switch (orderField)
                    {
                        case "Id":
                            cars = cars.OrderBy(c => c.Id);
                            break;
                        case "Year":
                            cars = cars.OrderBy(c => c.Year);
                            break;
                        case "Model":
                            cars = cars.OrderBy(c => c.Model);
                            break;
                        case "Price":
                            cars = cars.OrderBy(c => c.Price);
                            break;
                        case "Manufacturer":
                            cars = cars.OrderBy(c => c.Manufacturer.Name);
                            break;
                        case "Dealer":
                            cars = cars.OrderBy(c => c.Dealer.Name);
                            break;
                        default:
                            throw new ArgumentException("There is no such field in the database!");
                    }
                }

                this.SaveDataToFile(pathToXmlResultFiles + outputFileName, cars.ToList());
            }
        }

        private void SaveDataToFile(string pathToXmlQueries, IList<Car> cars)
        {
            var result = new XElement("Cars");

            foreach (var car in cars)
            {
                var xmlResultSet = new XElement("Car");
                xmlResultSet.SetAttributeValue("Manufacturer", car.Manufacturer.Name);
                xmlResultSet.SetAttributeValue("Model", car.Model);
                xmlResultSet.SetAttributeValue("Year", car.Year);
                xmlResultSet.SetAttributeValue("Price", car.Price);

                xmlResultSet.Add(new XElement("TransmissionType", car.TransmissionType.ToString().ToLower()));

                var xmlDealer = new XElement("Dealer");
                xmlDealer.SetAttributeValue("Name", car.Dealer.Name);
                var dealerCities = car.Dealer.Cities;

                if (dealerCities.Count() > 0)
                {
                    var xmlCities = new XElement("Cities");

                    foreach (var city in dealerCities)
                    {
                        xmlCities.Add(new XElement("City", city.Name));
                    }

                    xmlDealer.Add(xmlCities);
                }

                xmlResultSet.Add(xmlDealer);

                result.Add(xmlResultSet);
            }

            result.Save(pathToXmlQueries);
        }
    }
}