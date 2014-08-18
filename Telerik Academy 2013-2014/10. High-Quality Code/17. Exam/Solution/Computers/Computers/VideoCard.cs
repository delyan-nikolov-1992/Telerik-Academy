namespace Computers
{
    using System;

    public class VideoCard : IVideoCard
    {
        public VideoCard(ConsoleColor color)
        {
            this.Color = color;
        }

        public ConsoleColor Color { get; set; }

        public void Draw(string textData)
        {
            Console.ForegroundColor = this.Color;
            Console.WriteLine(textData);
            Console.ResetColor();
        }
    }
}