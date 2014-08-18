namespace Computers
{
    using System;

    public static class ComputersEntryPoint
    {
        public static void Main()
        {
            IGenerateComputers generateComputers;
            string manufacturer = Console.ReadLine();

            if (manufacturer == "HP")
            {
                generateComputers = new GenerateHPComputers();
            }
            else if (manufacturer == "Dell")
            {
                generateComputers = new GenerateDellComputers();
            }
            else if (manufacturer == "Lenovo")
            {
                generateComputers = new GenerateLenovoComputers();
            }
            else
            {
                throw new ArgumentException("Invalid manufacturer!");
            }

            var pc = generateComputers.GeneratePersonalComputer();
            var server = generateComputers.GenerateServer();
            var laptop = generateComputers.GenerateLaptop();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == null || command.StartsWith("Exit"))
                {
                    break;
                }

                var commandArguments = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandArguments.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandName = commandArguments[0];
                var number = int.Parse(commandArguments[1]);

                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(number);
                }
                else if (commandName == "Process")
                {
                    server.Process(number);
                }
                else if (commandName == "Play")
                {
                    pc.Play(number);
                }
                else
                {
                    throw new ArgumentException("Invalid command!");
                }
            }
        }
    }
}