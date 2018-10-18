using LineClient.AspNetCore.Messaging.Models.LineMessage.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace LineClient.AspNetCore.Messaging.Models.LineMessage.Implements
{
    public class LineMessageText : ILineMessageText
    {
        private readonly string toLineUserId;
        private readonly string message;
        public LineMessageText (string toLineUserId, string message)
        {
            this.toLineUserId = toLineUserId;
            this.message = message;
        }
        public StringContent GenerateStringContent()
        {
            dynamic JsonObj = new ExpandoObject();
            JsonObj.messages = new List<ExpandoObject>();
            JsonObj.to = toLineUserId;
            dynamic JsonObj_Message = new ExpandoObject();
            JsonObj_Message.type = "text";
            JsonObj_Message.text = message;
            JsonObj.messages.Add(JsonObj_Message);
            string JsonObjSerialize = JsonConvert.SerializeObject(JsonObj);
            StringContent stringContent = new StringContent(JsonObjSerialize, Encoding.UTF8, "application/json");
            return stringContent;
        }   
    }
}
