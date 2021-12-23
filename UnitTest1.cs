using System;
using Newtonsoft.Json.Linq;
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


        //[Test]
        //public void Test()
        //{
        //    string path = "/New.txt";
        //    var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Dropbox-API-Arg", "{\"path\": \"/New.txt\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}");
        //    request.AddHeader("Content-Type", "application/octet-stream");
        //    request.AddHeader("Authorization", "Bearer J6xF_bXHmbcAAAAAAAAAAaC0G5RkfoCPBq5S649CaYNlqBKbH6lw8muK1MkCha6V");
        //    var body = @"вапрол";
        //    request.AddParameter("application/octet-stream", body, ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);
        //    Console.WriteLine(response.Content);
        //    dynamic stuff = JObject.Parse(response.Content);
        //    string path_new = stuff["path_display"];
        //    Assert.AreEqual(path, path_new);

        //}



        [Test]
        public void Test1()
        {
            string path = "/New.txt";
            string ok = "OK";
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

            dynamic stuff = JObject.Parse(response1.Content);
            string path_new = stuff["path_display"];
            Console.WriteLine(path_new);
            Assert.AreEqual(path, path_new);
            string code= response1.StatusCode.ToString();
            Assert.AreEqual("OK", code);

        }

        [Test]
        public void Test2()
        {
            string path = "/New.txt";
            var client = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer J6xF_bXHmbcAAAAAAAAAAaC0G5RkfoCPBq5S649CaYNlqBKbH6lw8muK1MkCha6V");
            var body = @"{" + "\n" +
            @"    ""path"": ""/New.txt""" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            dynamic stuff = JObject.Parse(response.Content);
            string path_new = stuff["path_display"];
            Console.WriteLine(path_new);
            Assert.AreEqual(path, path_new);
            string code = response.StatusCode.ToString();
            Assert.AreEqual("OK", code);

        }



        [Test]
        public void Test3()
        {
            string path = "/New.txt";
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


            dynamic stuff = JObject.Parse(response.Content);
            string path_new = stuff["metadata"]["path_display"];
            Console.WriteLine(path_new);
            Assert.AreEqual(path, path_new);
            string code = response.StatusCode.ToString();
            Assert.AreEqual("OK", code);
        }

    }
}