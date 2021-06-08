using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lecture8HomeWork.Framework
{
    class ParseModel
    {
        public static PostsModel GetDes(string responseBody)
        {
            var responseDeserialization = JsonConvert.DeserializeObject<PostsModel>(responseBody);
            return responseDeserialization;
        }

        public static IList<PostsModel> GetDesList(string responseBody)
        {
            var responseDeserializationList = JsonConvert.DeserializeObject<IList<PostsModel>>(responseBody);
            return responseDeserializationList;
        }
    }
}