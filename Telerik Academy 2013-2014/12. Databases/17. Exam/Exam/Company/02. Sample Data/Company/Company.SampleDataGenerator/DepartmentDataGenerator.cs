namespace Company.SampleDataGenerator
{
    using System.Collections.Generic;

    using Company.Data;

    internal class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentDataGenerator(
            IRandomDataGenerator randomDataGenerator,
            CompanyEntities tosStoreEntities,
            ILogger logger,
            int countOfGeneratedObjects)
            : base(randomDataGenerator, tosStoreEntities, logger, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var departmentNamesToBeAdded = new HashSet<string>();

            while (departmentNamesToBeAdded.Count != this.Count)
            {
                departmentNamesToBeAdded.Add(this.Random.GetRandomStringWithRandomLength(10, 50));
            }

            int index = 0;

            Logger.LogMessageWithNewLine("Adding departments!");

            foreach (var departmentName in departmentNamesToBeAdded)
            {
                var department = new Department
                {
                    Name = departmentName
                };

                this.Database.Departments.Add(department);
                index++;

                if (index % 100 == 0)
                {
                    Logger.LogMessage(".");
                    this.Database.SaveChanges();
                }
            }

            Logger.LogMessageWithNewLine("\nDepartments added!");
        }
    }
}