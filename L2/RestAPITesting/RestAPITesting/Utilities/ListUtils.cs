using RestAPITesting.Models;

namespace RestAPITesting.Utilities
{
    public static class ListUtils
    {
        public static User GetById(this List<User> list, int id)
        {
            return list.Find(n => n.Id == id);
        }
    }
}