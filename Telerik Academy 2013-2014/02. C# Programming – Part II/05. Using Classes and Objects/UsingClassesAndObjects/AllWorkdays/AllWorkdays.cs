using System;

class AllWorkdays
{
    static void Main()
    {
        try
        {
            Console.Write("Enter the future date in the format (DD/MM/YYYY):");
            string[] givenDate = Console.ReadLine().Split('/');
            int day = int.Parse(givenDate[0]);
            int month = int.Parse(givenDate[1]);
            int year = int.Parse(givenDate[2]);

            if (day > 0 && day <= 31 && month > 0 && month <= 12 && year >= DateTime.Today.Year)
            {
                DateTime futureDate = new DateTime(year, month, day);
                int workdays = Workdays(futureDate);

                Console.WriteLine("Workdays left until {0}: {1}", futureDate, workdays);
            }
            else
            {
                Console.WriteLine("Enter a valid date!");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static int Workdays(DateTime lastDay)
    {
        //the official holidays this year and therefore the program work correctly only for this year
        DateTime[] officialHolidays = 
        { 
            new DateTime(2014, 1, 1), 
            new DateTime(2014, 3, 3), 
            new DateTime(2014, 4, 18),  
            new DateTime(2014, 5, 1), 
            new DateTime(2014, 5, 2), 
            new DateTime(2014, 5, 5), 
            new DateTime(2014, 5, 6), 
            new DateTime(2014, 9, 22), 
            new DateTime(2014, 12, 24), 
            new DateTime(2014, 12, 25), 
            new DateTime(2014, 12, 26), 
            new DateTime(2014, 12, 31) 
        };

        DateTime firstDay = DateTime.Now;
        TimeSpan span = lastDay - firstDay;
        int workDays = span.Days + 1;
        int fullWeekCount = workDays / 7;

        //find out if there are weekends during the time exceedng the full weeks
        if (workDays > fullWeekCount * 7)
        {
            //we are here to find out if there is a 1-day or 2-days weekend
            //in the time interval remaining after subtracting the complete weeks
            int firstDayOfWeek = (int)firstDay.DayOfWeek;
            int lastDayOfWeek = (int)lastDay.DayOfWeek;

            if (lastDayOfWeek < firstDayOfWeek)
            {
                lastDayOfWeek += 7;
            }

            if (firstDayOfWeek <= 6)
            {
                //both Saturday and Sunday are in the remaining time interval
                if (lastDayOfWeek >= 7)
                {
                    workDays -= 2;
                }
                //only Saturday is in the remaining time interval
                else if (lastDayOfWeek >= 6)
                {
                    workDays -= 1;
                }
            }
            //only Sunday is in the remaining time interval
            else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)
            {
                workDays -= 1;
            }
        }

        //subtract the weekends during the full weeks in the interval
        workDays -= fullWeekCount + fullWeekCount;

        //subtract the number of bank holidays during the time interval
        foreach (DateTime currentHoliday in officialHolidays)
        {
            if (firstDay <= currentHoliday && currentHoliday <= lastDay)
            {
                --workDays;
            }
        }

        return workDays;
    }
}