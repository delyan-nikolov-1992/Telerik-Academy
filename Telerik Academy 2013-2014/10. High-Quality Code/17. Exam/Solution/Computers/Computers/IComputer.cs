namespace Computers
{
    public interface IComputer
    {
        RamMemory Ram { get; set; }

        Cpu Cpu { get; set; }

        HardDrive HardDrive { get; set; }

        VideoCard VideoCard { get; set; }
    }
}