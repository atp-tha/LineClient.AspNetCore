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

        public async Task<LineChatRoomInfo> GetChatRoomInfoAsync(string chatRoomUserId, string lineUserId)
        {
            var data = await lineHttpClient.GetRoomProfileAsync(chatRoomUserId, lineUserId).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<LineChatRoomInfo>(Encoding.UTF8.GetString(data));
        }

        public async Task<LineUserInfo> GetUserInfoAsync(string userId)
        {
            var data = await lineHttpClient.GetProfileAsync(userId).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<LineUserInfo>(Encoding.UTF8.GetString(data));
        }

        public async Task<string> PushMessageAsync(ILineMessage StringContent, LineUserInfo userInfo)
        {   
            HttpClient client = await lineHttpClient.GetHttpClient();
            StringContent stringContent = StringContent.GenerateStringContent();
            HttpResponseMessage response = await client.PostAsync("https://api.line.me/v2/bot/message/push", stringContent);
            response.EnsureSuccessStatusCode();

            return "";
        }

        public Task PushMessageAsync(ILineMessage lineMessage, LineChatRoomInfo chatRoomInfo)
        {
            throw new System.NotImplementedException();
        }

        Task<LineChatRoomInfo> ILineMessagingClient.GetChatRoomInfoAsync(string roomId)
        {
            throw new System.NotImplementedException();
        }
    }
}
