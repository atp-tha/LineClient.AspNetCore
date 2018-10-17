using System;
using System.Collections.Generic;
using System.Text;

namespace LineClient.AspNetCore.Messaging.Models
{
    public class PushMessageModel
    {
        public string to { get; set; } // ToUser
        public List<MessageModel> messages { get; set; }
    }
}
