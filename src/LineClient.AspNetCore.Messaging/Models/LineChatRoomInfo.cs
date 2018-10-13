using System;
using System.Collections.Generic;
using System.Text;

namespace LineClient.AspNetCore.Messaging.Models
{
    public class LineChatRoomInfo
    {
        public string displayName { get; set; }
        public string userId { get; set; }
        public string pictureUrl { get; set; }
    }
}
