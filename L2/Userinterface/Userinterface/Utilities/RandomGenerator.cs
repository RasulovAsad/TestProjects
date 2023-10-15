using System.Security.Cryptography;
using System.Text;

namespace Userinterface.Utilities
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

        public static int GetRandomNumber(int maxValue)
        {
            int randomNumber;
            randomNumber = rand.Next(maxValue);
            return randomNumber;
        }

        public static int[] GenerateRandomArrayWithUniqueBValues(int arrayLength, int minValue, int maxValue, params int[] excludedValues)
        {
            int[] array = new int[arrayLength];

            for (int i = 0; i < arrayLength;)
            {
                int randomValue = rand.Next(minValue, maxValue + 1);
                bool isContinue = false;

                foreach (var item in array)
                {
                    if (randomValue == item)
                    {
                        isContinue = true;
                        break;
                    }

                    foreach (var excludedValue in excludedValues)
                    {
                        if (randomValue == excludedValue)
                        {
                            isContinue = true;
                            break;
                        }
                    }
                }

                if (!isContinue)
                {
                    array[i] = randomValue;
                    i++;
                }
            }

            return array;
        }
    }
}
