namespace Company.SampleDataGenerator
{
    using System.Linq;

    using Company.Data;

    internal class EmployeeDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployeeDataGenerator(
            IRandomDataGenerator randomDataGenerator,
            CompanyEntities tosStoreEntities,
            ILogger logger,
            int countOfGeneratedObjects)
            : base(randomDataGenerator, tosStoreEntities, logger, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var departmentIds = this.Database.Departments.Select(d => d.Id).ToList();

            Logger.LogMessageWithNewLine("Adding employees!");

            for (int i = 0; i < this.Count; i++)
            {
                var managerIds = this.Database.Employees.Select(m => m.Id).ToList();
                int? managerId = null;

                if (managerIds.Count > 0 && this.Random.GetChance(95))
                {
                    managerId = managerIds[this.Random.GetRandomInt(0, managerIds.Count - 1)];
                }

                var employee = new Employee
                {
                    FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    DepartmentId = departmentIds[this.Random.GetRandomInt(0, departmentIds.Count - 1)],
                    ManagerId = managerId,
                    YearSalary = (decimal)this.Random.GetRandomDouble(50000, 200000)
                };

                this.Database.Employees.Add(employee);

                if (i % 100 == 0)
                {
                    Logger.LogMessage(".");
                    this.Database.SaveChanges();
                }
            }

            Logger.LogMessageWithNewLine("\nEmployees added!");
        }
    }
}