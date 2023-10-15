using Newtonsoft.Json;
using Task3._1.Models;

namespace Task3._1.Framework.Utilities
{
    public static class FileReader
    {
        private static string _testdataPath = @"Data\testdata.json";
        private static string _usersdataPath = @"Data\users.json";

        public static Dictionary<string, dynamic> GetTestData()
        {
            Dictionary<string, dynamic> source;
            using (StreamReader reader = new StreamReader(_testdataPath))
            {
                string json = reader.ReadToEnd();
                source = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
            }
            return source;
        }

        public static List<User> GetUsersFromTestData()
        {
            List<User> users;

            using (StreamReader reader = new StreamReader(_usersdataPath))
            {
                string jsonUsers = reader.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            }
            return users;
            ;
        }
    }
}
