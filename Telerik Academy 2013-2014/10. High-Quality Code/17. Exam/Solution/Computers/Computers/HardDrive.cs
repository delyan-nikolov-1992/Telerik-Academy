namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDrive
    {
        private bool isInRaid;
        private int hardDrivesInRaid;
        private IEnumerable<HardDrive> hardDrives;
        private int capacity;
        private Dictionary<int, string> data;

        public HardDrive()
        {
        }

        public HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
            this.hardDrives = new List<HardDrive>();
        }

        public HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid, IEnumerable<HardDrive> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;
            this.data = (Dictionary<int, string>)new Dictionary<int, string>(capacity);
            this.hardDrives = hardDrives;
        }

        public int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hardDrives.Any())
                    {
                        return 0;
                    }

                    return this.hardDrives.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }
        }

        private void SaveData(int addr, string newData)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.hardDrives)
                {
                    hardDrive.SaveData(addr, newData);
                }
            }
            else
            {
                this.data[addr] = newData;
            }
        }

        private string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (!this.hardDrives.Any())
                {
                    throw new ArgumentNullException("No hard drive in the RAID array!");
                }

                return this.hardDrives.First().LoadData(address);
            }
            else if (true)
            {
                return this.data[address];
            }
        }
    }
}