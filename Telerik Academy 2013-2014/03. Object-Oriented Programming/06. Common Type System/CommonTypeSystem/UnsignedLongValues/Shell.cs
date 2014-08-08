namespace UnsignedLongValues
{
    using System;

    public class Shell
    {
        public static void Main()
        {
            try
            {
                BitArray64 myTestBitArray = new BitArray64(1546878);

                foreach (var item in myTestBitArray)
                {
                    Console.Write("{0}", item);
                }

                Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}