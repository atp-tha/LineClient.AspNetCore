using LineClient.AspNetCore.Messaging.Models.LineMessage.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace LineClient.AspNetCore.Messaging.Models.LineMessage.Implements
{
    public class LineMessageImage : ILineMessageImage
    {
        public StringContent GenerateStringContent(PushMessageModel message)
        {
            string JsonObjSerialize = JsonConvert.SerializeObject(message);
            StringContent stringContent = new StringContent(JsonObjSerialize, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
