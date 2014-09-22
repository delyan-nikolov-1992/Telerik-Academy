namespace Company.SampleDataGenerator
{
    using System;
    using System.Linq;

    using Company.Data;

    internal class ReportDataGenerator : DataGenerator, IDataGenerator
    {
        public ReportDataGenerator(
            IRandomDataGenerator randomDataGenerator,
            CompanyEntities tosStoreEntities,
            ILogger logger,
            int countOfGeneratedObjects)
            : base(randomDataGenerator, tosStoreEntities, logger, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var employeeIds = this.Database.Employees.Select(e => e.Id).ToList();

            Logger.LogMessageWithNewLine("Adding reports!");

            for (int i = 0; i < this.Count; i++)
            {
                var reportTime = this.Random.GetRandomDate(DateTime.Now.AddHours(i), DateTime.Now.AddHours(i + 5));

                var report = new Report
                {
                    ReportTime = reportTime,
                    EmployeeId = employeeIds[i / 50]
                };

                this.Database.Reports.Add(report);

                if (i % 100 == 0)
                {
                    Logger.LogMessage(".");
                    this.Database.SaveChanges();
                }
            }

            Logger.LogMessageWithNewLine("\nReports added!");
        }
    }
}