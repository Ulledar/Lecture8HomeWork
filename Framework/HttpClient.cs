using Flurl.Http;

namespace Lecture8HomeWork.Framework
{
    class HttpClient
    {
        readonly IFlurlClient flurlClient = new FlurlClient("https://jsonplaceholder.typicode.com");

        public IFlurlResponse Get(string segment)
        {
            var response = flurlClient.Request(segment).GetAsync().Result;
            return response;
        }

        public IFlurlResponse Post<T>(T model, string segment)
        {
            var response = flurlClient.Request(segment).PostJsonAsync(model).Result;
            return response;
        }

        public IFlurlResponse Put<T>(T model, string segment)
        {
            var response = flurlClient.Request(segment).PutJsonAsync(model).Result;
            return response;
        }

        public IFlurlResponse Patch(string title, string segment)
        {
            var response = flurlClient.Request(segment).PatchJsonAsync(new
            {
                title,
            }).Result;
            return response;
        }

        public IFlurlResponse Delete(string segment)
        {
            var response = flurlClient.Request(segment).DeleteAsync().Result;
            return response;
        }

        public static string Body(IFlurlResponse resValue)
        {
            var responseBody = resValue.ResponseMessage.Content.ReadAsStringAsync().Result;
            return responseBody;
        }        
    }
}