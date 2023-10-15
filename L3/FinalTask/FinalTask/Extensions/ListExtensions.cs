namespace FinalTask.Extensions
{
    public static class ListExtensions
    {
        public static List<T> OrderListByDescending<T>(this List<T> list, Comparison<T> comparison)
        {
            list.Sort(comparison);
            list.Reverse();
            return list;
        }
    }
}
