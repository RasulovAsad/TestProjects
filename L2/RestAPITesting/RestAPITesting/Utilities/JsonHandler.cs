using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestAPITesting.Utilities
{
    public static class JsonHandler
    {
        public static T GetTestDataFromJson<T>(string fileName)
        {
            T source;
            using (StreamReader reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "TestData", fileName)))
            {
                string json = reader.ReadToEnd();
                source = JsonConvert.DeserializeObject<T>(json);
            }
            return source;
        }

        public static string GetValue(string filePath, string path)
        {
            JObject result;
            using (StreamReader reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, filePath)))
            {
                string json = reader.ReadToEnd();
                result = JObject.Parse(json);
            }

            var resultProperty = result.SelectToken(path);

            return resultProperty.ToString();
        }

        public static bool CompareTwoObjects<T>(T firstObject, T secondObject)
        {
            return JToken.DeepEquals(JToken.FromObject(firstObject), JToken.FromObject(secondObject));
        }

        public static int GetIdByPropertyName(string filePath, string path)
        {
            var stringProperty = JsonHandler.GetValue(filePath, path);
            int result = int.Parse(stringProperty);
            return result;
        }
    }
}
