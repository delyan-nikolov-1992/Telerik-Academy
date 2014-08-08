namespace MobilePhone
{
    using System;

    public class GSMTest
    {
        private const int SIZE = 3;

        public static void RunTest()
        {
            GSM[] mobilePhones = new GSM[SIZE];
            mobilePhones[0] = new GSM("Nokia E5", "Nokia", "BL-4D");
            mobilePhones[1] = new GSM("Samsung Galaxy S4", "Samsung Electronics", 799.99f, "I9500");
            mobilePhones[2] = 
                new GSM("Nexus 5", "LG Electronics", 699.99f, "Dinko Dinev", "BL-T9", 300, 17, BatteryType.LiPo, 12.5f, 16000000);

            foreach (GSM currentMobilePhone in mobilePhones)
            {
                Console.WriteLine(currentMobilePhone.ToString());
            }

            Console.WriteLine(GSM.IPhone4S.ToString());
        }
    }
}