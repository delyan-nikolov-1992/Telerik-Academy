namespace Company.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;

    internal class EmployeeProjectRelationDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployeeProjectRelationDataGenerator(
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
            var projectIds = this.Database.Projects.Select(p => p.Id).ToList();

            Logger.LogMessageWithNewLine("Adding employee-project relations!");

            for (int i = 0; i < this.Count; i++)
            {
                var employeeIdsToBeAdded = new HashSet<int>();
                int numberOfEmployees = this.Random.GetRandomInt(2, 20);

                while (employeeIdsToBeAdded.Count != numberOfEmployees)
                {
                    employeeIdsToBeAdded.Add(employeeIds[this.Random.GetRandomInt(0, employeeIds.Count - 1)]);
                }

                foreach (var employeeId in employeeIdsToBeAdded)
                {
                    var startDate = this.Random.GetRandomDate(
                        DateTime.Now.AddHours((i + numberOfEmployees) * (-1)), 
                        DateTime.Now.AddHours(((i + numberOfEmployees) * (-1)) - 5));

                    var endDate = this.Random.GetRandomDate(startDate, startDate.AddDays(this.Random.GetRandomInt(5, 20)));

                    var employeeProjectRelation = new EmployeesProject
                    {
                        EmployeeId = employeeId,
                        ProjectId = projectIds[i],
                        StartDate = startDate,
                        EndDate = endDate
                    };

                    this.Database.EmployeesProjects.Add(employeeProjectRelation);
                }

                if ((i + numberOfEmployees) % 100 == 0)
                {
                    Logger.LogMessage(".");
                    this.Database.SaveChanges();
                }
            }

            Logger.LogMessageWithNewLine("\nEmployee-project relations added!");
        }
    }
}