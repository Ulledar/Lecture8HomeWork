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
        readonly Responses myRes = new();

        [Test]
        public void GetTest()
        {
            var response = myRes.GetResponse();
            var responseBody = Responses.ResponseBody(response);
            var deserializationList = Responses.PutDeserializationList(responseBody);

            Assert.AreEqual(200, response.StatusCode, "We get different Status code");
            for (int i = 1; i <= deserializationList.Count; i++) Assert.AreEqual(deserializationList[i - 1].Id, i, "Wrong ID");
            WriteLine(responseBody);
        }

        [Test]
        public void PostTest()
        {
            string title = "Homework task. Lecture 8";
            string body = "some body";
            int userId = 69;

            var response = myRes.PostResponse(title, body, userId);
            var responseBody = Responses.ResponseBody(response);
            var responseDeserialization = Responses.PutDeserialization(responseBody);

            Assert.AreEqual(201, response.StatusCode, "We get different Status code");
            Assert.AreEqual(responseDeserialization.Title, title, "We get different title");
            Assert.AreEqual(responseDeserialization.Body, body, "We get different body");
            WriteLine(responseBody);
        }

        [Test]
        public void PutTest()
        {
            string title = "Homework task. Lecture 8";
            string body = "some body";
            int userId = 69;

            var response = myRes.PutResponse(1 , title, body, userId);
            var responseBody = Responses.ResponseBody(response);
            var responseDeserialization = Responses.PutDeserialization(responseBody);

            Assert.AreEqual(200, response.StatusCode, "We get different Status code");
            Assert.AreEqual(responseDeserialization.Title, title, "We get different title");
            Assert.AreEqual(responseDeserialization.Body, body, "We get different body");
            Assert.AreEqual(responseDeserialization.UserId, userId, "We get different ID");
            WriteLine(responseBody);
        }

        [Test]
        public void PatchTest()
        {
            string title = "Homework task. Lecture 8";

            var response = myRes.PatchResponse(title);
            var responseBody = Responses.ResponseBody(response);
            var responseDeserialization = Responses.PutDeserialization(responseBody);

            Assert.AreEqual(200, response.StatusCode, "We get different Status code");
            Assert.AreEqual(responseDeserialization.Title, title, "We get different title");
            WriteLine(responseBody);
        }

        [Test]
        public void DeleteTest()
        {
            var response = myRes.DeleteResponse();
            var responseBody = Responses.ResponseBody(response);

            Assert.AreEqual(200, response.StatusCode, "We get different Status code");
            WriteLine(responseBody);
            WriteLine(response.ResponseMessage.StatusCode.ToString());
            WriteLine("Status code " + (int)response.ResponseMessage.StatusCode);
        }
    }
}