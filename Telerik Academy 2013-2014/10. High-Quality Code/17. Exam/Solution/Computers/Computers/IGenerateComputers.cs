namespace Computers
{
    public interface IGenerateComputers
    {
        PersonalComputer GeneratePersonalComputer();

        Server GenerateServer();

        Laptop GenerateLaptop();
    }
}