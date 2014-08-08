namespace FarmVille
{
    public class Cat : Animal, ISound
    {
        public Cat(byte age, string name, bool isMale)
            : base(age, name, isMale)
        {

        }

        public string Sound()
        {
            return "Mew!";
        }
    }
}