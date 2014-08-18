namespace Computers
{
    public interface IRamMemory
    {
        void SaveValue(int newValue);

        int LoadValue();
    }
}