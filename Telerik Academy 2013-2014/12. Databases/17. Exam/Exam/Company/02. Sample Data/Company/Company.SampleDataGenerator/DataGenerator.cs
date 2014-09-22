namespace Company.SampleDataGenerator
{
    using Company.Data;

    internal abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private ILogger logger;
        private int count;

        public DataGenerator(
            IRandomDataGenerator randomDataGenerator,
            CompanyEntities companyEntities,
            ILogger logger,
            int countOfGeneratedObjects)
        {
            this.random = randomDataGenerator;
            this.db = companyEntities;
            this.logger = logger;
            this.count = countOfGeneratedObjects;
        }

        protected IRandomDataGenerator Random
        {
            get
            {
                return this.random;
            }
        }

        protected CompanyEntities Database
        {
            get
            {
                return this.db;
            }
        }

        protected ILogger Logger
        {
            get
            {
                return this.logger;
            }
        }

        protected int Count
        {
            get
            {
                return this.count;
            }
        }

        public abstract void Generate();
    }
}