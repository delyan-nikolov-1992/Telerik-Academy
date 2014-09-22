namespace Company.SampleDataGenerator
{
    using Company.Data;

    internal class ProjectDataGenerator : DataGenerator, IDataGenerator
    {
        public ProjectDataGenerator(
            IRandomDataGenerator randomDataGenerator,
            CompanyEntities tosStoreEntities,
            ILogger logger,
            int countOfGeneratedObjects)
            : base(randomDataGenerator, tosStoreEntities, logger, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Logger.LogMessageWithNewLine("Adding projects!");

            for (int i = 0; i < this.Count; i++)
            {
                var project = new Project
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50)
                };

                this.Database.Projects.Add(project);

                if (i % 100 == 0)
                {
                    Logger.LogMessage(".");
                    this.Database.SaveChanges();
                }
            }

            Logger.LogMessageWithNewLine("\nProjects added!");
        }
    }
}