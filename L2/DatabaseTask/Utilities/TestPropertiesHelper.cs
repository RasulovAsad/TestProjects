namespace DatabaseTask.Utilities
{
    public static class TestPropertiesHelper
    {
        public static string GetStatusId(NUnit.Framework.Interfaces.TestStatus status)
        {
            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    return "1";
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    return "2";
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    return "3";
                default:
                    return "2";
            }
        }

        public static string GetFormattedTime(DateTime time) => time.ToString("yyyy-MM-dd hh:mm:ss");
    }
}
