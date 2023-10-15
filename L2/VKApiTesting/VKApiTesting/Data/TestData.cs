using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace VKApiTesting.Data
{
    public static class TestData
    {
        private static ISettingsFile data = new JsonSettingsFile("Resources.TestData.data.json", Assembly.GetCallingAssembly());

        public static int MaxLengthForPostText => data.GetValue<int>(".maxLengthForPostText");
        public static int AlbumId => data.GetValue<int>(".albumId");
        public static string ImagePath => data.GetValue<string>(".imagePath");
        public static string DownloadedImagePath => data.GetValue<string>(".downloadedImagePath");
    }
}
