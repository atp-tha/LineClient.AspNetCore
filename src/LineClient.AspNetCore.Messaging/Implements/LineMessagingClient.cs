using LineClient.AspNetCore.Messaging.Interfaces;
using LineClient.AspNetCore.Messaging.Models;
using LineClient.AspNetCore.Messaging.Models.LineMessage;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LineClient.AspNetCore.Messaging.Implements
{
    public class LineMessagingClient : ILineMessagingClient
    {
        private readonly ILineHttpClient lineHttpClient;

        public LineMessagingClient(ILineHttpClient lineHttpClient)
        {
            this.lineHttpClient = lineHttpClient;
        }

        public async Task<LineChatRoomInfo> GetChatRoomInfoAsync(string roomId, string userId)
        {
            var data = await lineHttpClient.GetRoomProfileAsync(roomId, userId).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<LineChatRoomInfo>(Encoding.UTF8.GetString(data));
        }

        public async Task<LineUserInfo> GetUserInfoAsync(string userId)
        {
            var data = await lineHttpClient.GetProfileAsync(userId).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<LineUserInfo>(Encoding.UTF8.GetString(data));
        }

        public async Task PushMessageAsync(ILineMessage lineMessage, LineUserInfo userInfo)
        {   
            StringContent stringContent = lineMessage.GenerateStringContent();
        }

        public Task PushMessageAsync(ILineMessage lineMessage, LineChatRoomInfo chatRoomInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}
