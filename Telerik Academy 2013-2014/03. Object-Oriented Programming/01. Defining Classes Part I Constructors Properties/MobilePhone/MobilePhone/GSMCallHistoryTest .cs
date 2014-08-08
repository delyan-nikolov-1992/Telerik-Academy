namespace MobilePhone
{
    using System;

    public class GSMCallHistoryTest
    {
        private const int SIZE = 3;
        private const float PRICE_PER_MINUTE = 0.37f;

        public static void RunTest()
        {
            GSM currentGSM = new GSM("HTC One", "HTC", "BJ83100");
            currentGSM.AddCall(new Call(new DateTime(2014, 01, 01, 0, 0, 0), "0888995432", 59));
            currentGSM.AddCall(new Call(new DateTime(2014, 01, 06, 12, 0, 0), "0874294333", 61));
            currentGSM.AddCall(new Call(DateTime.Now, "0899195432", 120));

            foreach (Call currentCall in currentGSM.CallHistory)
            {
                Console.WriteLine(currentCall.ToString());
            }

            Console.WriteLine("The total price of the calls in the history is " + currentGSM.CallsPrice(PRICE_PER_MINUTE).ToString("C"));
            currentGSM.DeleteLongestCall();
            Console.WriteLine("\nThe total price of the calls in the history is " + currentGSM.CallsPrice(PRICE_PER_MINUTE).ToString("C"));
            currentGSM.ClearCallHistory();

            if (currentGSM.CallHistory.Count == 0)
            {
                Console.WriteLine("\nThere are no made calls from this phone.");
            }
        }
    }
}