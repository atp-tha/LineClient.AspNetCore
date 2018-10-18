using LineClient.AspNetCore.Messaging.Models.LineMessage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace LineClient.AspNetCore.Messaging.Models.LineMessage.Implements
{
    public class LineImageMessage : ILineImageMessage
    {
        public StringContent GenerateStringContent()
        {
            throw new NotImplementedException();
        }
    }
}
