namespace Company.SampleDataGenerator
{
    using System.Collections.Generic;

    using Company.Data;

    internal class SampleData
    {
        private static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;
            var logger = new Logger();

            var listOfGenerators
                = new List<IDataGenerator>
            {
                new DepartmentDataGenerator(random, db, logger, 100),
                new EmployeeDataGenerator(random, db, logger, 5000),
                new ProjectDataGenerator(random, db, logger, 1000),
                new EmployeeProjectRelationDataGenerator(random, db, logger, 1000),
                new ReportDataGenerator(random, db, logger, 250000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}