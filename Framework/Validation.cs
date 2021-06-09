using NUnit.Framework;

namespace Lecture8HomeWork.Framework
{
    class Validation
    {
        public static void AssertPostModel(CreatePostModel request, PostModel response)
        {
            Assert.AreEqual(request.title, response.title, "Title is mismatched");
            Assert.AreEqual(request.body, response.body, "Body is mismatched");
            Assert.AreEqual(request.userId, response.userId, "User id is mismatched");
            Assert.That(response.id > 0 , "No id");
        }

        public static void AssertPutModel(UpdatePostModel request, PostModel response)
        {
            Assert.AreEqual(request.title, response.title, "Title is mismatched");
            Assert.AreEqual(request.body, response.body, "Body is mismatched");
            Assert.AreEqual(request.userId, response.userId, "User id is mismatched");
            Assert.AreEqual(request.id, response.id, "Id is mismatched");
        }
    }
}