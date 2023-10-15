namespace VKApiTesting.Extensions
{
    public static class ListExtensions
    {
        public static string JoinAllItems(this List<string> list, char separator)
        {
            return string.Join(separator, list);
        }
    }
}
