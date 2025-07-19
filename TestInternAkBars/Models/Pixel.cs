namespace TestInternAkBars.Models
{
    public class Pixel
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public Pixel(byte r, byte g, byte b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }

        public int GetLuminance() => (Red + Green + Blue) / 3;
    }
}
