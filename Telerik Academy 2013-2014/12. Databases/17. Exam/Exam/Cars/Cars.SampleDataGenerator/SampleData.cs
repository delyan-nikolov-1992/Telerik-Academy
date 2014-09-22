namespace Cars.SampleDataGenerator
{
    using System;

    using Cars.Data;
    using Cars.Models;

    public class SampleData
    {
        private const string PathToJSONImport = "../../../JSON files/";
        private const string PathToXmlQueries = "../../../Queries.xml";
        private const string PathToXmlResultFiles = "../../../Query results/";

        public static void Main()
        {
            try
            {
                CarsDbContext db = new CarsDbContext();

                CarsImporter importer = new CarsImporter(db);
                importer.ImportData(PathToJSONImport);
                CarsExporter exporter = new CarsExporter(db);
                exporter.ExportData(PathToXmlQueries, PathToXmlResultFiles);
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}