namespace Computers
{
    using System;
    using System.Collections.Generic;

    public class Server : MotherBoard, IComputer, IMotherboard
    {
        public Server(Cpu cpu, RamMemory ram, IEnumerable<HardDrive> hardDrives, HardDrive hardDrive, VideoCard videoCard)
            : base(cpu, ram, hardDrives, hardDrive, videoCard)
        {
        }

        public override VideoCard VideoCard
        {
            get
            {
                return base.VideoCard;
            }

            set
            {
                if (value.Color != ConsoleColor.Gray)
                {
                    throw new ArgumentException("The video card of the server should be monochrome!");
                }

                base.VideoCard = value;
            }
        }

        public void Process(int number)
        {
            this.SaveRamValue(number);

            var squaredNumber = this.Cpu.SquareNumber();

            if (squaredNumber == -1)
            {
                this.DrawOnVideoCard("Number too low.");
            }
            else if (squaredNumber == -2)
            {
                this.DrawOnVideoCard("Number too high.");
            }
            else
            {
                this.DrawOnVideoCard(string.Format("Square of {0} is {1}.", number, squaredNumber));
            }
        }
    }
}