using System;
using System.Collections.Generic;
using System.Text;

namespace LineClient.AspNetCore.Messaging.Models
{
    public class MessageModel
    {
        public string type { get; set; }
        public string text { get; set; }
    }
}
