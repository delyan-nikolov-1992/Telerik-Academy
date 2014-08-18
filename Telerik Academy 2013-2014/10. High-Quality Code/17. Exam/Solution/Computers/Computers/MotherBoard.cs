namespace Computers
{
    using System.Collections.Generic;

    public abstract class MotherBoard : IComputer, IMotherboard
    {
        public MotherBoard(Cpu cpu, RamMemory ram, IEnumerable<HardDrive> hardDrives, HardDrive hardDrive, VideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrive = hardDrive;
            this.VideoCard = videoCard;
        }

        public Cpu Cpu { get; set; }

        public RamMemory Ram { get; set; }

        public IEnumerable<HardDrive> HardDrives { get; set; }

        public HardDrive HardDrive { get; set; }

        public virtual VideoCard VideoCard { get; set; }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }
    }
}