using System.Security.Cryptography;
using System.Text;

namespace VKApiTesting.Utilities
{
    public static class RandomGenerator
    {
        private static Random rand = new Random();

        private static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public static string GetUniqueKey(int size, string subString = "")
        {
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }
            result.Append(subString);

            return result.ToString();
        }

        public static int GetRandomNumber(int maxValue) => rand.Next(maxValue);
    }
}
