using System.Drawing;
using VKApiTesting.Constants;

namespace VKApiTesting.Utilities
{
    public static class ImageComparator
    {
        private static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(ImageComparatorConstants.Width, ImageComparatorConstants.Height));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < ImageComparatorConstants.BrightnessLevelThreshold);
                }
            }
            return lResult;
        }

        public static bool CompareImages(string firstImagePath, string secondImagePath)
        {
            List<bool> iHash1 = GetHash(new Bitmap(firstImagePath));
            List<bool> iHash2 = GetHash(new Bitmap(secondImagePath));

            int equalElements = iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);

            return equalElements > ImageComparatorConstants.equalBitsThreshold;
        }
    }
}
