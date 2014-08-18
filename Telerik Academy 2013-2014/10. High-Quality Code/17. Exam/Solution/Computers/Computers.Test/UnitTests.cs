namespace Computers.Test
{
    using System;
    using Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ChargeBatteryWithZero()
        {
            Battery battery = new Battery();
            int persentage = 0;

            int batteryPercentageBeforeCharging = battery.Percentage;
            battery.Charge(persentage);
            int batteryPercentageAfterCharging = battery.Percentage;

            Assert.AreEqual(
                batteryPercentageBeforeCharging,
                batteryPercentageAfterCharging - persentage,
                string.Format("Actual value: {0}, Expected value: {1}", batteryPercentageBeforeCharging, batteryPercentageAfterCharging));
        }

        [TestMethod]
        public void ChargeBatteryWithNegativeNumber()
        {
            Battery battery = new Battery();
            int persentage = -10;

            int batteryPercentageBeforeCharging = battery.Percentage;
            battery.Charge(persentage);
            int batteryPercentageAfterCharging = battery.Percentage - persentage;

            Assert.AreEqual(
                batteryPercentageBeforeCharging,
                batteryPercentageAfterCharging,
                string.Format("Actual value: {0}, Expected value: {1}", batteryPercentageBeforeCharging, batteryPercentageAfterCharging));
        }

        [TestMethod]
        public void ChargeBatteryWithPositiveNumber()
        {
            Battery battery = new Battery();
            int persentage = 10;

            int batteryPercentageBeforeCharging = battery.Percentage;
            battery.Charge(persentage);
            int batteryPercentageAfterCharging = battery.Percentage - persentage;

            Assert.AreEqual(
                batteryPercentageBeforeCharging,
                batteryPercentageAfterCharging,
                string.Format("Actual value: {0}, Expected value: {1}", batteryPercentageBeforeCharging, batteryPercentageAfterCharging));
        }

        [TestMethod]
        public void ChargeBatteryWithPositiveNumberBiggerThan100()
        {
            Battery battery = new Battery();
            int persentage = 110;

            battery.Charge(persentage);
            int actualBattery = battery.Percentage;
            int expextedBattery = 100;

            Assert.AreEqual(
                actualBattery,
                expextedBattery,
                string.Format("Actual value: {0}, Expected value: {1}", actualBattery, expextedBattery));
        }

        [TestMethod]
        public void ChargeBatteryWithNegativeNumberSmallerThanMinus100()
        {
            Battery battery = new Battery();
            int persentage = -110;

            battery.Charge(persentage);
            int actualBattery = battery.Percentage;
            int expextedBattery = 0;

            Assert.AreEqual(
                actualBattery,
                expextedBattery,
                string.Format("Actual value: {0}, Expected value: {1}", actualBattery, expextedBattery));
        }

        [TestMethod]
        public void TestRandomIntFromIntervallInclusiveFromNumberOneToNumberOne()
        {
            var ram = new RamMemory(4);
            var hardDrive = new HardDrive();
            var cpu = new Cpu(2, 64, ram, hardDrive);

            var value = 1;
            var number = cpu.RandomIntFromIntervallInclusive(value, value);

            Assert.AreEqual(
                number,
                value,
                string.Format("Actual value: {0}, Expected value: {1}", number, value));
        }

        [TestMethod]
        public void TestSquareNumberValue()
        {
            var ram = new RamMemory(4);
            var hardDrive = new HardDrive();
            var cpu = new Cpu(2, 64, ram, hardDrive);

            var input = 5;
            var value = 25;
            var number = cpu.SquareOfNumber(input);

            Assert.AreEqual(
                number,
                value,
                string.Format("Actual value: {0}, Expected value: {1}", number, value));
        }

        [TestMethod]
        public void TestSquareNumberValueWith0()
        {
            var ram = new RamMemory(4);
            var hardDrive = new HardDrive();
            var cpu = new Cpu(2, 64, ram, hardDrive);

            var input = 0;
            var value = 0;
            var number = cpu.SquareOfNumber(input);

            Assert.AreEqual(
                number,
                value,
                string.Format("Actual value: {0}, Expected value: {1}", number, value));
        }
    }
}