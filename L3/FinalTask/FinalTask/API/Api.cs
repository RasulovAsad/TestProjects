using Aquality.Selenium.Browsers;
using FinalTask.Configurations;
using FinalTask.Constants;
using FinalTask.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FinalTask.API
{
    public static class Api
    {
        private static readonly RestClient client = new RestClient(Config.ApiUrl);

        public static string GetToken(string variant)
        {
            AqualityServices.Logger.Info("[API] Getting access token");
            var request = new RestRequest(Endpoints.GetToken, Method.Post);
            request.AddParameter("variant", variant);
            var response = client.Execute(request);
            return response.Content;
        }

        public static List<TestModel> GetAllTestsByProjectId(string projectId)
        {
            AqualityServices.Logger.Info($"[API] Getting all tests from project with id={projectId}");
            var request = new RestRequest(Endpoints.GetTests, Method.Post);
            request.AddParameter("projectId", projectId);
            int numberOfTries = 1;

            while (true)
            {
                var response = client.Execute(request);
                try
                {
                    return JsonConvert.DeserializeObject<List<TestModel>>(response.Content);
                }
                catch (Exception ex)
                {
                    numberOfTries++;
                    if (numberOfTries < Config.MaxApiRequestTries)
                    {
                        continue;
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        public static string PutTest(TestModel model)
        {
            AqualityServices.Logger.Info("[API] Adding test to the project");
            var request = new RestRequest(Endpoints.PutTest, Method.Post);
            request.AddParameter("SID", model.SessionId);
            request.AddParameter("projectName", model.ProjectName);
            request.AddParameter("testName", model.Name);
            request.AddParameter("methodName", model.Method);
            request.AddParameter("env", model.Env);
            request.AddParameter("startTime", model.StartTime);
            request.AddParameter("browser", model.BrowserName);
            var response = client.Execute(request);
            return response.Content;
        }

        public static void AddLogToTest(string testId, string content)
        {
            AqualityServices.Logger.Info("[API] Adding log to the test");
            var request = new RestRequest(Endpoints.AddLogToTest, Method.Post);
            request.AddParameter("testId", testId);
            request.AddParameter("content", content);
            client.Execute(request);
        }

        public static void AddAttachmentToTest(string testId, string content, string contentType)
        {
            AqualityServices.Logger.Info("[API] Adding attachment to the test");
            var request = new RestRequest(Endpoints.AddAttachmentToTest, Method.Post);
            request.AddParameter("testId", testId);
            request.AddParameter("content", content);
            request.AddParameter("contentType", contentType);
            client.Execute(request);
        }

        public static void UpdateTest(string testId, string status, string endTime)
        {
            AqualityServices.Logger.Info("[API] Updating a test");
            var request = new RestRequest(Endpoints.UpdateTest, Method.Post);
            request.AddParameter("testId", testId);
            request.AddParameter("status", status);
            request.AddParameter("endTime", endTime);
            client.Execute(request);
        }
    }
}