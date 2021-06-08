using Flurl.Http;

namespace Lecture8HomeWork.Framework
{
    class Responses
    {
        readonly IFlurlClient flurlClient = new FlurlClient("https://jsonplaceholder.typicode.com");
        const string PostsSegment = "posts";
        const string PostsSegmentOne = "posts/1";


        public IFlurlResponse Get()
        {
            var response = flurlClient.Request(PostsSegment).GetAsync().Result;
            return response;
        }

        public IFlurlResponse Post(PostsModel model)
        {
            var response = flurlClient.Request(PostsSegment).PostJsonAsync(new
            {
                model.Title,
                model.Body,
                model.UserId,
            }).Result;
            return response;
        }

        public IFlurlResponse Put(PostsModel model)
        {
            var response = flurlClient.Request(PostsSegmentOne).PutJsonAsync(new
            {
                model.Id,
                model.Title,
                model.Body,
                model.UserId,
            }).Result;
            return response;
        }

        public IFlurlResponse Patch(string title)
        {
            var response = flurlClient.Request(PostsSegmentOne).PatchJsonAsync(new
            {
                title,
            }).Result;
            return response;
        }

        public IFlurlResponse Delete()
        {
            var response = flurlClient.Request(PostsSegmentOne).DeleteAsync().Result;
            return response;
        }

        public static string Body(IFlurlResponse resValue)
        {
            var responseBody = resValue.ResponseMessage.Content.ReadAsStringAsync().Result;
            return responseBody;
        }        
    }
}