using LineClient.AspNetCore.Messaging.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace LineClient.AspNetCore.Messaging.Implements
{
    public class LineHttpClient : ILineHttpClient
    {
        private readonly HttpClient _client;
        private readonly string lineApiV2Url = "https://api.line.me/v2";

        public LineHttpClient(HttpClient client, string channelAccessToken)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + channelAccessToken);

            _client = client;
        }

        public Task<byte[]> GetProfileAsync(string userId)
        {
            return _client.GetByteArrayAsync($"{lineApiV2Url}/bot/profile/{userId}");
        }

        public Task<byte[]> GetRoomProfileAsync(string roomId, string userId)
        {
            return _client.GetByteArrayAsync($"{lineApiV2Url}/bot/room/{roomId}/member/{userId}");
        }

        public async Task PushMessage(StringContent message)
        {
            HttpResponseMessage response = await _client.PostAsync($"{lineApiV2Url}/bot/message/push", message);
            response.EnsureSuccessStatusCode();
        }
    }
}
