using NUnit.Framework;

namespace FinalTask.Utilities
{
    public static class LogUtil
    {
        public static string GetLogs()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Log/log.log");
            string text;
            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }
            var logs = text.Split("====================================================================================================");
            Console.WriteLine(logs.Reverse().Skip(1).FirstOrDefault());
            return logs.Reverse().Skip(1).FirstOrDefault();
        }
    }
}
