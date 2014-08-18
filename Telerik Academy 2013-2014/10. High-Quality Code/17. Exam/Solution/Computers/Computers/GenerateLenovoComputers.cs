namespace Computers
{
    using System;
    using System.Collections.Generic;

    public class GenerateLenovoComputers : IGenerateComputers
    {
        public PersonalComputer GeneratePersonalComputer()
        {
            var ram = new RamMemory(4);
            var hardDrive = new HardDrive();
            var videoCard = new VideoCard(ConsoleColor.Gray);
            var cpu = new Cpu(2, 64, ram, hardDrive);
            var hardDrives = new[] 
            { 
                new HardDrive(2000, false, 0) 
            };

            var pc = new PersonalComputer(cpu, ram, hardDrives, hardDrive, videoCard);

            return pc;
        }

        public Server GenerateServer()
        {
            var ram = new RamMemory(8);
            var hardDrive = new HardDrive();
            var videoCard = new VideoCard(ConsoleColor.Gray);
            var cpu = new Cpu(2, 128, ram, hardDrive);

            var hardDrivesList = new HardDrive(
                0, 
                true, 
                2, 
                new List<HardDrive> 
            { 
                new HardDrive(500, false, 0), 
                new HardDrive(500, false, 0) 
            });

            var hardDrives = new List<HardDrive>
                    {
                        hardDrivesList
                    };

            var server = new Server(cpu, ram, hardDrives, hardDrive, videoCard);

            return server;
        }

        public Laptop GenerateLaptop()
        {
            var ram = new RamMemory(16);
            var hardDrive = new HardDrive();
            var videoCard = new VideoCard(ConsoleColor.Green);
            var cpu = new Cpu(2, 64, ram, hardDrive);
            var battery = new Battery();
            var hardDrives = new[] 
            { 
                new HardDrive(1000, false, 0) 
            };

            var laptop = new Laptop(cpu, ram, hardDrives, hardDrive, videoCard, battery);

            return laptop;
        }
    }
}