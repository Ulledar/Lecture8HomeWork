using NUnit.Framework;

namespace Lecture8HomeWork.Framework
{
    class Validation
    {
        public static void AssertPostModel(PostsModel request, PostsModel response)
        {
            Assert.AreEqual(request.Title, response.Title, "Title is mismatched");
            Assert.AreEqual(request.Body, response.Body, "Body is mismatched");
            Assert.AreEqual(request.UserId, response.UserId, "User id is mismatched");
            Assert.AreEqual(request.Id, response.Id, "Id is mismatched");
        }
    }
}