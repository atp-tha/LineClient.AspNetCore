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

        public Task<byte[]> GetProfileAsync(string UID)
        {
            return _client.GetByteArrayAsync($"{lineApiV2Url}/bot/profile/{UID}");
        }
    }
}
