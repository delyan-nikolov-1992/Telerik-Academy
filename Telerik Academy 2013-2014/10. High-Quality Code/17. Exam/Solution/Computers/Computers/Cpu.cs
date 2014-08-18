namespace Computers
{
    using System;

    public class Cpu
    {
        private const int MinSquareValue = 0;
        private const int MaxSquareValue32Bit = 500;
        private const int MaxSquareValue64Bit = 1000;
        private const int MaxSquareValue128Bit = 2000;

        private static readonly Random Random = new Random();

        private readonly byte numberOfBits;
        private readonly RamMemory ramMemory;
        private readonly HardDrive hardDrive;

        public Cpu(byte numberOfCores, byte numberOfBits, RamMemory ram, HardDrive hardDrive)
        {
            this.NumberOfCores = numberOfCores;
            this.numberOfBits = numberOfBits;
            this.ramMemory = ram;
            this.hardDrive = hardDrive;
        }

        private byte NumberOfCores { get; set; }

        public int SquareNumber()
        {
            int squareNumber = 0;
            int maxValue = 0;

            if (this.numberOfBits == 32)
            {
                maxValue = MaxSquareValue32Bit;
            }
            else if (this.numberOfBits == 64)
            {
                maxValue = MaxSquareValue64Bit;
            }
            else if (this.numberOfBits == 128)
            {
                maxValue = MaxSquareValue128Bit;
            }

            squareNumber = this.SquareNumberValue(MinSquareValue, maxValue);

            return squareNumber;
        }

        public void SaveValueToRamMemory(int minValue, int maxValue)
        {
            int randomNumber = this.RandomIntFromIntervallInclusive(minValue, maxValue + 1);

            this.ramMemory.SaveValue(randomNumber);
        }

        public int RandomIntFromIntervallInclusive(int minValue, int maxValue)
        {
            int randomNumber = Random.Next(minValue, maxValue + 1);

            return randomNumber;
        }

        public int SquareOfNumber(int value)
        {
            int result = 0;

            for (int i = 0; i < value; i++)
            {
                result += value;
            }

            return result;
        }

        private int SquareNumberValue(int minValue, int maxValue)
        {
            var data = this.ramMemory.LoadValue();

            if (data < minValue)
            {
                return -1;
            }
            else if (data > maxValue)
            {
                return -2;
            }
            else
            {
                return this.SquareOfNumber(data);
            }
        }
    }
}