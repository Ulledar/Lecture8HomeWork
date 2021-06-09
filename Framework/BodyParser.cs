using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lecture8HomeWork.Framework
{
    class BodyParser
    {
        public static PostModel GetDes(string responseBody)
        {
            var responseDeserialization = JsonConvert.DeserializeObject<PostModel>(responseBody);
            return responseDeserialization;
        }

        public static IList<PostModel> GetDesList(string responseBody)
        {
            var responseDeserializationList = JsonConvert.DeserializeObject<IList<PostModel>>(responseBody);
            return responseDeserializationList;
        }
    }
}