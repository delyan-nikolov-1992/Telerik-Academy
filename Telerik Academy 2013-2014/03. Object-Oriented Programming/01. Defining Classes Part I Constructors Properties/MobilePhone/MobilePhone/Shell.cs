namespace MobilePhone
{
    using System;

    public class Shell
    {
        public static void Main()
        {
            try
            {
                GSMTest.RunTest();
                GSMCallHistoryTest.RunTest();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}