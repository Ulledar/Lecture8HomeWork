using Lecture8HomeWork.Framework;
using NUnit.Framework;
using static System.Console;

namespace Lecture8HomeWork
{
    [TestFixture]
    public class MyTest
    {
        readonly Responses myRes = new ();

        [Test]
        public void GetTest()
        {
            var response = myRes.Get();
            var responseBody = Responses.Body(response);
            var deserializationList = ParseModel.GetDesList(responseBody);

            Assert.AreEqual(200, response.StatusCode, "Status code is mismatched");
            for (int i = 1; i <= deserializationList.Count; i++) Assert.AreEqual(i, deserializationList[i - 1].Id, "Wrong ID");
            WriteLine(responseBody);
        }               

        [Test]
        public void PostTest()
        {
            PostsModel testData = new();
            testData.Body = "some body";
            testData.Title = "Homework task. Lecture 8";
            testData.UserId = 69;
            testData.Id = 101;

            var response = myRes.Post(testData);
            var responseBody = Responses.Body(response);
            var responseDeserialization = ParseModel.GetDes(responseBody);

            Assert.AreEqual(201, response.StatusCode, "Status code is mismatched");
            Validation.AssertPostModel(testData, responseDeserialization);
            WriteLine(responseBody);
        }

        [Test]
        public void PutTest()
        {
            PostsModel testData = new();
            testData.Body = "some body";
            testData.Title = "Homework task. Lecture 8";
            testData.UserId = 69;
            testData.Id = 1;

            var response = myRes.Put(testData);
            var responseBody = Responses.Body(response);
            var responseDeserialization = ParseModel.GetDes(responseBody);

            Assert.AreEqual(200, response.StatusCode, "Status code is mismatched");
            Validation.AssertPostModel(testData, responseDeserialization);
            WriteLine(responseBody);
        }

        [Test]
        public void PatchTest()
        {
            string title = "Homework task. Lecture 8";

            var response = myRes.Patch(title);
            var responseBody = Responses.Body(response);
            var responseDeserialization = ParseModel.GetDes(responseBody);

            Assert.AreEqual(200, response.StatusCode, "Status code is mismatched");
            Assert.AreEqual(title, responseDeserialization.Title, "Title is mismatched");
            WriteLine(responseBody);
        }

        [Test]
        public void DeleteTest()
        {
            var response = myRes.Delete();
            var responseBody = Responses.Body(response);

            Assert.AreEqual(200, response.StatusCode, "Status code is mismatched");
            WriteLine(responseBody);
            WriteLine(response.ResponseMessage.StatusCode.ToString());
            WriteLine("Status code " + (int)response.ResponseMessage.StatusCode);
        }
    }
}