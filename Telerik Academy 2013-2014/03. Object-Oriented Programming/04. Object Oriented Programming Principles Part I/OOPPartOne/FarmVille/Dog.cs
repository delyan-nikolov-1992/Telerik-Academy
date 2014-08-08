namespace FarmVille
{
    public class Dog : Animal, ISound
    {
        public Dog(byte age, string name, bool isMale)
            : base(age, name, isMale)
        {

        }

        public string Sound()
        {
            return "Woof!";
        }
    }
}