// <copyright file="CountFactorial.cs" company="Anonymous Company">
// Copyright (c) 2012 All Rights Reserved
// </copyright>
// <author>Anonymous</author>
// <date>06/27/2014 11:39:58 AM </date>
// <summary>Class representing factorial counting.</summary>

namespace Factorial
{
    using System;
    using System.Numerics;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// The class that tests the factorial of a number.
    /// </summary>
    public class CountFactorial
    {
        /// <summary>
        /// Logger that logs the errors, warnings, etc.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(CountFactorial));

        /// <summary>
        /// The main method that tests the functionality of the program.
        /// </summary>
        public static void Main()
        {
            BasicConfigurator.Configure();

            try
            {
                Console.Write("n = ");
                BigInteger number = BigInteger.Parse(Console.ReadLine());

                if (number >= 0)
                {
                    Console.WriteLine("n! = " + Factorial(number));
                }
                else
                {
                    Console.WriteLine("n should not be negative");
                }
            }
            catch (FormatException)
            {
                Log.Error("The input should be an integer!");
            }
            catch (OverflowException)
            {
                Log.Error("The input should be in the boundaries of an integer!");
            }
            catch (OutOfMemoryException)
            {
                Log.Error("There is no free space!");
            }
        }

        /// <summary>
        /// Returns the factorial of the input number using recursion.
        /// </summary>
        /// <param name="number">the input number</param>
        /// <returns>the factorial of the input number</returns>
        private static BigInteger Factorial(BigInteger number)
        {
            return number == 0 ? 1 : number * Factorial(number - 1);
        }
    }
}