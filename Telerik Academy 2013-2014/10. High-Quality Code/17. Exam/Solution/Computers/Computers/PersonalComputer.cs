namespace Computers
{
    using System.Collections.Generic;

    public class PersonalComputer : MotherBoard, IComputer
    {
        public PersonalComputer(Cpu cpu, RamMemory ram, IEnumerable<HardDrive> hardDrives, HardDrive hardDrive, VideoCard videoCard)
            : base(cpu, ram, hardDrives, hardDrive, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.SaveValueToRamMemory(1, 10);
            var number = this.LoadRamValue();

            if (number + 1 != guessNumber + 1)
            {
                this.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.DrawOnVideoCard("You win!");
            }
        }
    }
}