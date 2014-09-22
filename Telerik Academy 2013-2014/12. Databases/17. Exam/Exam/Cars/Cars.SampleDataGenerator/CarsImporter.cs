namespace Cars.SampleDataGenerator
{
    using System.IO;
    using System.Linq;

    using Cars.Data;
    using Cars.Models;

    using Newtonsoft.Json.Linq;

    public class CarsImporter
    {
        private CarsDbContext db;

        public CarsImporter(CarsDbContext db)
        {
            this.db = db;
        }

        public void ImportData(string pathToJSONImport)
        {
            foreach (string file in Directory.EnumerateFiles(pathToJSONImport, "*.json"))
            {
                string json = File.ReadAllText(file);
                var jsonObjs = JArray.Parse(json);

                foreach (var jsonObj in jsonObjs)
                {
                    int year = int.Parse(jsonObj["Year"].ToString());
                    TransmissionType transmissionType = (TransmissionType)int.Parse(jsonObj["TransmissionType"].ToString());
                    string manufacturerName = jsonObj["ManufacturerName"].ToString();
                    string model = jsonObj["Model"].ToString();
                    decimal price = decimal.Parse(jsonObj["Price"].ToString());
                    string dealerName = jsonObj["Dealer"]["Name"].ToString();
                    string cityName = jsonObj["Dealer"]["City"].ToString();

                    var manufacturer = this.GetManufacturer(manufacturerName);
                    var dealer = this.GetDealer(dealerName);
                    var city = this.GetCity(cityName);

                    dealer.Cities.Add(city);

                    var car = new Car
                    {
                        Year = year,
                        TransmissionType = transmissionType,
                        Manufacturer = manufacturer,
                        Model = model,
                        Price = price,
                        Dealer = dealer
                    };

                    this.db.Cars.Add(car);
                    this.db.SaveChanges();
                }
            }
        }

        private Manufacturer GetManufacturer(string manufacturerName)
        {
            var manufacturer = this.db.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);

            if (manufacturer == null)
            {
                manufacturer = new Manufacturer
                {
                    Name = manufacturerName
                };
            }

            return manufacturer;
        }

        private Dealer GetDealer(string dealerName)
        {
            var dealer = this.db.Dealers.FirstOrDefault(d => d.Name == dealerName);

            if (dealer == null)
            {
                dealer = new Dealer
                {
                    Name = dealerName
                };
            }

            return dealer;
        }

        private City GetCity(string cityName)
        {
            var city = this.db.Cities.FirstOrDefault(c => c.Name == cityName);

            if (city == null)
            {
                city = new City
                {
                    Name = cityName
                };
            }

            return city;
        }
    }
}