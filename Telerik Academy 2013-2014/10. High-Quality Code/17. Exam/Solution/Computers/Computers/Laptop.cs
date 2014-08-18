namespace Computers
{
    using System.Collections.Generic;

    public class Laptop : MotherBoard, IComputer
    {
        public Laptop(Cpu cpu, RamMemory ram, IEnumerable<HardDrive> hardDrives, HardDrive hardDrive, VideoCard videoCard, Battery battery)
            : base(cpu, ram, hardDrives, hardDrive, videoCard)
        {
            this.Battery = battery;
        }

        public Battery Battery { get; set; }

        public void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            this.DrawOnVideoCard(string.Format("Battery status: {0}%", this.Battery.Percentage));
        }
    }
}