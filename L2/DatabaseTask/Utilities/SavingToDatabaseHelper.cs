using Aquality.Selenium.Browsers;
using DatabaseTask.Data;
using Humanizer;
using NUnit.Framework;
using System.Data;

namespace DatabaseTask.Utilities
{
    public static class SavingToDatabaseHelper
    {
        private static string ScenarioName
            => TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
            ?? TestContext.CurrentContext.Test.Name.Replace("_", string.Empty).Humanize();
        private static string startTime;

        public static void SetStartTime(DateTime time)
        {
            startTime = TestPropertiesHelper.GetFormattedTime(time);
        }

        private static string GetStartTime()
        {
            return startTime;
        }

        public static void SaveSession()
        {
            int buildNumber = RandomGenerator.GetRandomNumber(int.MaxValue);
            DatabaseUtil.Add("session", "session_key, created_time, build_number",
                $"'{AqualityServices.Browser.Driver.SessionId}', '{TestPropertiesHelper.GetFormattedTime(DateTime.Now)}', '{buildNumber}'");
        }

        private static long GetLastSessionId()
        {
            DataTable session;
            DatabaseUtil.Get(out session, "MAX(Id)", "session");
            return Convert.ToInt64(session.Rows[0].ItemArray.FirstOrDefault());
        }

        public static void SaveTestResult()
        {
            var statusId = TestPropertiesHelper.GetStatusId(TestContext.CurrentContext.Result.Outcome.Status);
            var methodName = TestContext.CurrentContext.Test.FullName;
            var sessionId = GetLastSessionId();
            var endTime = TestPropertiesHelper.GetFormattedTime(DateTime.Now);
            var env = Environment.UserName;
            var browserName = AqualityServices.Browser.BrowserName;
            DatabaseUtil.Add("test",
                "name, status_id, method_name, project_id, session_id, start_time, end_time, env, browser",
                $"'{ScenarioName}', '{statusId}', '{methodName}', '{TestData.ProjectId}', '{sessionId}', '{GetStartTime()}', '{endTime}', '{env}', '{browserName}'");
        }
    }
}
