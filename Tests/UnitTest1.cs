using Flurl.Http;
using Lecture8HomeWork.Framework;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using static System.Console;

namespace Lecture8HomeWork
{
    [TestFixture]
    public class Tests
    {
        readonly IFlurlClient flurlClient = new FlurlClient("https://jsonplaceholder.typicode.com");

        [Test]
        public void GetTest()
        {
            var response = flurlClient.Request("posts").GetAsync().Result;
            var responseBody = response.ResponseMessage.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<IList<Coments>>(responseBody);

            if (200 == response.StatusCode) WriteLine("Status code 200");
            if (200 != response.StatusCode) WriteLine("We get different Status code");            
            Assert.AreEqual(200, response.StatusCode);
            WriteLine(res[0].Title);
            WriteLine(res[0].Body);
            WriteLine(responseBody);
        }

        [Test]
        public void PostTest()
        {
            string title = "Homework task. Lecture 8";
            string body = "some body";

            var response = flurlClient.Request("posts").PostJsonAsync(new
                {
                    title = title,
                    body = body,
                    userId = 69,
                });
            var responseBody = response.Result.ResponseMessage.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<Coments>(responseBody);

            if (201 == response.Result.StatusCode) WriteLine("Status code 201");
            if (201 != response.Result.StatusCode) WriteLine("We get different Status code");
            Assert.AreEqual(201, response.Result.StatusCode);
            Assert.AreEqual(res.Title, title);
            WriteLine(res.Title);
            WriteLine(res.Body);
            WriteLine(responseBody);
        }

        [Test]
        public void PutTest()
        {
            string title = "Homework task. Lecture 8";
            string body = "some body";

            var response = flurlClient.Request("posts/1").PutJsonAsync(new
            {
                id = 1,
                title = title,
                body = body,
                userId = 69,
            });
            var responseBody = response.Result.ResponseMessage.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<Coments>(responseBody);

            if (200 == response.Result.StatusCode) WriteLine("Status code 200");
            if (200 != response.Result.StatusCode) WriteLine("We get different Status code");
            Assert.AreEqual(200, response.Result.StatusCode);
            Assert.AreEqual(res.Title, title);
            WriteLine(res.Title);
            WriteLine(res.Body);
            WriteLine(responseBody);
        }

        [Test]
        public void PatchTest()
        {
            string title = "Homework task. Lecture 8";

            var response = flurlClient.Request("posts/1").PatchJsonAsync(new
            {
                title = title,
            });
            var responseBody = response.Result.ResponseMessage.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<Coments>(responseBody);

            if (200 == response.Result.StatusCode) WriteLine("Status code 200");
            if (200 != response.Result.StatusCode) WriteLine("We get different Status code");
            Assert.AreEqual(200, response.Result.StatusCode);
            Assert.AreEqual(res.Title, title);
            WriteLine(res.Title);
            WriteLine(res.Body);
            WriteLine(responseBody);
        }

        [Test]
        public void DeleteTest()
        {
            var response = flurlClient.Request("posts/1").DeleteAsync().Result;
            var responseBody = response.ResponseMessage.Content.ReadAsStringAsync().Result;

            if (200 == response.StatusCode) WriteLine("Status code 200");
            if (200 != response.StatusCode) WriteLine("We get different Status code");
            Assert.AreEqual(200, response.StatusCode);
            WriteLine(responseBody);
            WriteLine(response.ResponseMessage.StatusCode.ToString());
            WriteLine("Status code " + (int)response.ResponseMessage.StatusCode);
        }
    }
}