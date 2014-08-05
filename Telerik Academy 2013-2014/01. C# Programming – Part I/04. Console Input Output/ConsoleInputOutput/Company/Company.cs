using System;

class Company
{
    static void Main()
    {
        try
        {
            Console.Write("The name of the company: ");
            string name = Console.ReadLine();
            Console.Write("The address of the company: ");
            string address = Console.ReadLine();
            Console.Write("The phone number of the company: ");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.Write("The fax number of the company: ");
            long faxNumber = long.Parse(Console.ReadLine());
            Console.Write("The web site of the company: ");
            string webSite = Console.ReadLine();
            Console.Write("The first name of the manager: ");
            string managerFirstName = Console.ReadLine();
            Console.Write("The last name of the manager: ");
            string managerLastName = Console.ReadLine();
            Console.Write("The age of the manager: ");
            byte managerAge = byte.Parse(Console.ReadLine());
            Console.Write("The phone number of the manager: ");
            long managerPhoneNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("\nThe name of the company is " + name);
            Console.WriteLine("The address of the company is " + address);
            Console.WriteLine("The phone number of the company is " + phoneNumber);
            Console.WriteLine("The fax number of the company is " + faxNumber);
            Console.WriteLine("The web site of the company is " + webSite);
            Console.WriteLine("The first name of the manager is " + managerFirstName);
            Console.WriteLine("The last name of the manager is " + managerLastName);
            Console.WriteLine("The age of the manager is " + managerAge);
            Console.WriteLine("The phone number of the manager is " + managerPhoneNumber);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}