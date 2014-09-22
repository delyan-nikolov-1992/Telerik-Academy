namespace Northwind
{
    using System.Data.Linq;

    public partial class Employee
    {
        public EntitySet<Territory> EntityTerritories
        {
            get
            {
                var employeeTerritories = this.Territories;
                EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
                entityTerritories.AddRange(employeeTerritories);

                return entityTerritories;
            }
        }
    }
}