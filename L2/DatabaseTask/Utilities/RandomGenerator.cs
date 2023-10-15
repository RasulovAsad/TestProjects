namespace DatabaseTask.Utilities
{
    public static class RandomGenerator
    {
        private static Random rand = new Random();
        public static int GetRandomNumber(int maxValue) => rand.Next(maxValue);
    }
}
