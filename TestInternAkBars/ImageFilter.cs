using TestInternAkBars.Models;

namespace TestInternAkBars
{
    public static class ImageFilter
    {
        public static Pixel[,] ApplyMedianFilter(Pixel[,] image)
        {
            int height = image.GetLength(0);
            int width = image.GetLength(1);

            var result = new Pixel[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result[y, x] = GetMedianPixel(image, x, y, width, height);
                }
            }

            return result;
        }

        private static Pixel GetMedianPixel(Pixel[,] image, int x, int y, int width, int height)
        {
            List<Pixel> window = new List<Pixel>();

            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {
                    int newX = x + i;
                    int newY = y + j;

                    if (newX < 0) newX = 0;
                    if (newX >= width) newX = width - 1;
                    if (newY < 0) newY = 0;
                    if (newY >= height) newY = height - 1;

                    window.Add(image[newY, newX]);
                }
            }

            window.Sort((p1, p2) => p1.GetLuminance().CompareTo(p2.GetLuminance()));

            return window[4]; 
        }
    }
}
