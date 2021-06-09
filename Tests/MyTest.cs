using Lecture8HomeWork.Framework;
using NUnit.Framework;
using static System.Console;

namespace Lecture8HomeWork
{
    [TestFixture]
    public class MyTest
    {
        readonly HttpClient myRes = new ();

        [Test]
        public void GetTest()
        {
            string postSegment = "posts";

            var response = myRes.Get(postSegment);
            var responseBody = HttpClient.Body(response);
            var deserializationList = BodyParser.GetDesList(responseBody);

            Assert.AreEqual(200, response.StatusCode, "Status code is mismatched");
            for (int i = 1; i <= deserializationList.Count; i++) Assert.AreEqual(i, deserializationList[i - 1].Id, "Wrong ID");
            WriteLine(responseBody);
        }

        [Test]
        public void PostTest()
        {
            string postSegment = "posts";

            CreatePostModel testData = new();
            testData.Body = "some body";
            testData.Title = "Homework task. Lecture 8";
            testData.UserId = 69;

            var response = myRes.Post<CreatePostModel>(testData, postSegment);
            var responseBody = HttpClient.Body(response);
            var responseDeserialization = BodyParser.GetDes(responseBody);

            Assert.AreEqual(201, response.StatusCode, "Status code is mismatched");
            Validation.AssertPostModel(testData, responseDeserialization);
            WriteLine(responseBody);
        }

        [Test]
        public void PutTest()
        {
            string postSegment = "posts/1";

            UpdatePostModel testData = new();
            testData.Body = "some body";
            testData.Title = "Homework task. Lecture 8";
            testData.UserId = 69;
            testData.Id = 1;

            var response = myRes.Put<UpdatePostModel>(testData, postSegment);
            var responseBody = HttpClient.Body(response);
            var responseDeserialization = BodyParser.GetDes(responseBody);

            Assert.AreEqual(200, response.StatusCode, "Status code is mismatched");
            Validation.AssertPutModel(testData, responseDeserialization);
            WriteLine(responseBody);
        }

        [Test]
        public void PatchTest()
        {
            string postSegment = "posts/1";
            string title = "Homework task. Lecture 8";

            var response = myRes.Patch(title, postSegment);
            var responseBody = HttpClient.Body(response);
            var responseDeserialization = BodyParser.GetDes(responseBody);

            Assert.AreEqual(200, response.StatusCode, "Status code is mismatched");
            Assert.AreEqual(title, responseDeserialization.Title, "Title is mismatched");
            WriteLine(responseBody);
        }

        [Test]
        public void DeleteTest()
        {
            string postSegment = "posts/1";

            var response = myRes.Delete(postSegment);
            var responseBody = HttpClient.Body(response);

            Assert.AreEqual(200, response.StatusCode, "Status code is mismatched");
            WriteLine(responseBody);
            WriteLine(response.ResponseMessage.StatusCode.ToString());
            WriteLine("Status code " + (int)response.ResponseMessage.StatusCode);
        }
    }
}