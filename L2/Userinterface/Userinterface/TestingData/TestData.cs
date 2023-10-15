using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Userinterface.TestingData
{
    public static class TestData
    {
        private static ISettingsFile testData = new JsonSettingsFile("Resources.testData.json", Assembly.GetCallingAssembly());

        public static string ImageName => testData.GetValue<string>(".ImageFileName");
        public static int PasswordLength => testData.GetValue<int>(".passwordLength");
        public static int EmailLength => testData.GetValue<int>(".emailLength");
        public static int DomainLength => testData.GetValue<int>(".domainLength");
        public static string ExpectedTime => testData.GetValue<string>(".expectedTime");
    }
}
