namespace Phones
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PhonesTest
    {
        private static ICollection<Person> persons;

        public static void Main()
        {
            try
            {
                persons = new HashSet<Person>();

                using (StreamReader reader = new StreamReader(".../.../phones.txt"))
                {

                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] arguments = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        Person person = CreatePerson(arguments);
                        persons.Add(person);
                    }
                }

                using (StreamReader reader = new StreamReader(".../.../commands.txt"))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        ExecuteCommand(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }

        private static Person CreatePerson(string[] arguments)
        {
            string[] names = arguments[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            IList<string> namesAsList = new List<string>();

            foreach (var currentName in names)
            {
                if (!string.IsNullOrWhiteSpace(currentName))
                {
                    namesAsList.Add(currentName.Trim());
                }
            }

            var Person = new Person
            {
                Names = namesAsList,
                Town = arguments[1].Trim(),
                PhoneNumber = arguments[2].Trim()
            };

            return Person;
        }

        private static void ExecuteCommand(string line)
        {
            string[] arguments = line.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (arguments[0].Trim() == "find")
            {
                if (arguments.Length == 2)
                {
                    FindPersonsByName(arguments[1].Trim());
                }
                else if (arguments.Length == 3)
                {
                    FindPersonsByNameAndTown(arguments[1].Trim(), arguments[2].Trim());
                }
            }
        }

        private static void FindPersonsByName(string name)
        {
            Console.WriteLine("All persons by given name '{0}':", name);

            foreach (var person in persons)
            {
                if (person.Names.Contains(name))
                {
                    Console.WriteLine(person);
                }
            }

            Console.WriteLine();
        }

        private static void FindPersonsByNameAndTown(string name, string town)
        {
            Console.WriteLine("All persons by given name '{0}' and town '{1}':", name, town);

            foreach (var person in persons)
            {
                if (person.Names.Contains(name) && person.Town == town)
                {
                    Console.WriteLine(person);
                }
            }

            Console.WriteLine();
        }
    }
}