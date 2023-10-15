using RestSharp;
using Serilog;

namespace RestAPITesting.Utilities
{
    public static class RequestHelper
    {
        public static RestResponse ExecuteRequest(RestClient client, RestRequest request, Method method)
        {
            var response = client.Execute(request, method);
            Log.Information($"Response status code: {response.StatusCode}");
            return response;
        }
    }
}
