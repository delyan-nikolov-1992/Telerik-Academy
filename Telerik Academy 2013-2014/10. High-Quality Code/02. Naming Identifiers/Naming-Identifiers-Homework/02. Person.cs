public class Test
{
    private enum Gender
    {
        Male,
        Female
    }

    public void CreatePerson(int age)
    {
        Person person = new Person();
        person.Age = age;

        if (age % 2 == 0)
        {
            person.Name = "Ivan";
            person.Gender = Gender.Male;
        }
        else
        {
            person.Name = "Maria";
            person.Gender = Gender.Female;
        }
    }

    private class Person
    {
        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}