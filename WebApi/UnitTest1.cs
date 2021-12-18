using System;
using NUnit.Framework;
using RestSharp;


namespace WebAPI
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            var client1 = new RestClient("https://content.dropboxapi.com/2/files/upload");
            client1.Timeout = -1;
            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("Dropbox-API-Arg", "{\"path\": \"/New.txt\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}");
            request1.AddHeader("Content-Type", "application/octet-stream");
            request1.AddHeader("Authorization", "Bearer J6xF_bXHmbcAAAAAAAAAAaC0G5RkfoCPBq5S649CaYNlqBKbH6lw8muK1MkCha6V");
            var body1 = @"test!";
            request1.AddParameter("application/octet-stream", body1, ParameterType.RequestBody);
            IRestResponse response1 = client1.Execute(request1);
            Console.WriteLine(response1.Content);

            var client2 = new RestClient("https://api.dropboxapi.com/2/sharing/get_file_metadata");
            client2.Timeout = -1;
            var request2 = new RestRequest(Method.POST);
            request2.AddHeader("Content-Type", "application/json");
            request2.AddHeader("Authorization", "Bearer J6xF_bXHmbcAAAAAAAAAAaC0G5RkfoCPBq5S649CaYNlqBKbH6lw8muK1MkCha6V");
            var body2 = @"{" + "\n" +
            @"    ""file"": ""id:HJ1Ayac16hMAAAAAAAAABw""," + "\n" +
            @"    ""actions"": []" + "\n" +
            @"}";
            request2.AddParameter("application/json", body2, ParameterType.RequestBody);
            IRestResponse response2 = client2.Execute(request2);
            Console.WriteLine(response2.Content);

            var client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer J6xF_bXHmbcAAAAAAAAAAaC0G5RkfoCPBq5S649CaYNlqBKbH6lw8muK1MkCha6V");
            var body = @"{" + "\n" +
            @"    ""path"":""/New.txt"" " + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            // Assert.Pass();
        }

    }
}