using NUnit.Framework;
using RestSharp;
using Serilog;
using System.Net;

namespace RestAPITesting.Steps
{
    public static class ApiSteps
    {
        public static void CheckThatStatusCodeIsExpected(HttpStatusCode statusCode, RestResponse response)
        {
            Log.Information("[STEP] Check that response status code is expected");
            Assert.AreEqual(statusCode, response.StatusCode, $"Status code should be {(int)statusCode}");
        }

        public static void CheckThatIsNotEmpty<T>(T response)
        {
            Log.Information("[STEP] Check that value is not empty");
            Assert.That(response, Is.Not.Empty, "Value should not be empty");
        }

        public static void CheckThatValuesAreEqual<T>(T expectedValue, T actualValue)
        {
            Log.Information($"[STEP] Check if {actualValue} is equal to {expectedValue.ToString()}");
            Assert.AreEqual(expectedValue, actualValue, "Actual value should match expected value");
        }
    }
}
