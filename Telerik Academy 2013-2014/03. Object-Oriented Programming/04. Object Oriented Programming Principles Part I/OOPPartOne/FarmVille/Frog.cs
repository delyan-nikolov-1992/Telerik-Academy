namespace FarmVille
{
    public class Frog : Animal, ISound
    {
        public Frog(byte age, string name, bool isMale)
            : base(age, name, isMale)
        {

        }

        public string Sound()
        {
            return "Croak!";
        }
    }
}