namespace WarMachines.Machines
{
    using System;
    using WarMachines.Interfaces;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string initialName)
        {
            this.Name = initialName;
            machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null!");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("Machine cannot be null!");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();

            string pilotName = this.Name;
            string numberOfMachines = this.machines.Count == 0 ? "no" : this.machines.Count.ToString();
            string machineWord = this.machines.Count == 1 ? "machine" : "machines";

            result.Append(string.Format("{0} - {1} {2}", pilotName, numberOfMachines, machineWord));

            if (this.machines.Count != 0)
            {
                var sortedMachines = this.machines
                                         .OrderBy(m => m.HealthPoints)
                                         .ThenBy(m => m.Name);

                result.AppendLine();

                for (int i = 0; i < sortedMachines.Count(); i++)
                {
                    result.Append(sortedMachines.ElementAt(i));

                    if (i != sortedMachines.Count() - 1)
                    {
                        result.AppendLine();
                    }
                }
            }

            return result.ToString();
        }
    }
}
