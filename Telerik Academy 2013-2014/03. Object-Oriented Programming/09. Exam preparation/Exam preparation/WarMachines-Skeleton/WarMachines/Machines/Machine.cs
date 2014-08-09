﻿namespace WarMachines.Machines
{
    using System;
    using WarMachines.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Machine : IMachine
    {
        protected const string ON = "ON";
        protected const string OFF = "OFF";

        private string name;
        private IPilot pilot;
        private IList<string> targets;

        public Machine(string name, double healthPoints, double attackPoints, double defencePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defencePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the machine cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Engaged pilot cannot be null!");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            get
            {
                return new List<String>(targets);
            }
        }

        public void Attack(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentNullException("The target cannot be null or empty!");
            }

            this.targets.Add(target);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            string targetsAsString = this.targets.Count == 0 ? "None" : string.Join(", ", this.targets);

            result.AppendLine(string.Format("- {0}", this.name));
            result.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            result.Append(string.Format(" *Targets: {0}", targetsAsString));

            return result.ToString();
        }
    }
}