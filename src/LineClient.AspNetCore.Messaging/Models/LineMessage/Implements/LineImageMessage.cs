using LineClient.AspNetCore.Messaging.Models.LineMessage.Interfaces;
using System;
using System.Net.Http;

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
