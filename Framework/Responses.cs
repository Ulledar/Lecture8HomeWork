using Flurl.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lecture8HomeWork.Framework
{
    class Responses
    {
        readonly IFlurlClient flurlClient = new FlurlClient("https://jsonplaceholder.typicode.com");
        const string PostsSegment = "posts";
        const string PostsSegmentOne = "posts/1";


        public IFlurlResponse GetResponse()
        {
            var response = flurlClient.Request(PostsSegment).GetAsync().Result;
            return response;
        }

        public IFlurlResponse PostResponse(string title, string body, int userId)
        {
            var response = flurlClient.Request(PostsSegment).PostJsonAsync(new
            {
                title,
                body,
                userId,
            }).Result;
            return response;
        }

        public IFlurlResponse PutResponse(int id, string title, string body, int userId)
        {
            var response = flurlClient.Request(PostsSegmentOne).PutJsonAsync(new
            {
                id,
                title,
                body,
                userId,
            }).Result;
            return response;
        }

        public IFlurlResponse PatchResponse(string title)
        {
            var response = flurlClient.Request(PostsSegmentOne).PatchJsonAsync(new
            {
                title,
            }).Result;
            return response;
        }

        public IFlurlResponse DeleteResponse()
        {
            var response = flurlClient.Request(PostsSegmentOne).DeleteAsync().Result;
            return response;
        }

        public static string ResponseBody(IFlurlResponse resValue)
        {
            var responseBody = resValue.ResponseMessage.Content.ReadAsStringAsync().Result;
            return responseBody;
        }

        public static PostsModel PutDeserialization(string responseBody)
        {
            var responseDeserialization = JsonConvert.DeserializeObject<PostsModel>(responseBody);
            return responseDeserialization;
        }

        public static IList<PostsModel> PutDeserializationList(string responseBody)
        {
            var responseDeserializationList = JsonConvert.DeserializeObject<IList<PostsModel>>(responseBody);
            return responseDeserializationList;
        }
    }
}