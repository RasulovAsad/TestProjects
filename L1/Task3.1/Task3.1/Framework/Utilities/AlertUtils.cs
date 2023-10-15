using OpenQA.Selenium;
using Serilog;
using System.Security.Cryptography;
using System.Text;
using Task3._1.Framework.Driver;

namespace Task3._1.Framework.Utilities
{
    public class AlertUtils
    {
        private static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public static string GetUniqueKey(int size)
        {
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        public static bool IsAlertPresent()
        {
            try
            {
                Log.Debug("Alert appeared on the page");
                Thread.Sleep(300);
                Browser.GetDriver().SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException Ex)
            {
                return false;
            }
        }

        public static string GetAlertMessage()
        {
            return Browser.GetDriver().SwitchTo().Alert().Text;
        }

        public static void DismissAlert()
        {
            Log.Information("User clicked OK");
            Browser.GetDriver().SwitchTo().Alert().Dismiss();
        }

        public static void AcceptAlert()
        {
            Log.Information("User clicked OK");
            Browser.GetDriver().SwitchTo().Alert().Accept();
        }

        public static void SendKeysToAlert(string key)
        {
            Log.Information("User filled text field in alert");
            Browser.GetDriver().SwitchTo().Alert().SendKeys(key);
        }
    }
}
