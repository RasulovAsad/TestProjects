using RestSharp;

namespace VKApiTesting.Utilities
{
    public class ApiHelper
    {
        public static void DownloadImage(string downloadUrl, string outputPath)
        {
            RestClient imageDownloadClient = new RestClient(downloadUrl);
            var fileBytes = imageDownloadClient.DownloadData(new RestRequest("#", Method.Get));
            File.WriteAllBytes(Path.Combine(Environment.CurrentDirectory, outputPath), fileBytes);
        }

        public static RestResponse ExecuteRequest(RestClient client, RestRequest request, Method method)
        {
            var response = client.Execute(request, method);
            return response;
        }
    }
}
