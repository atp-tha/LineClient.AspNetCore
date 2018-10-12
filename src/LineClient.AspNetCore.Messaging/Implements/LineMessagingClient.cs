using LineClient.AspNetCore.Messaging.Interfaces;
using LineClient.AspNetCore.Messaging.Models;
using Newtonsoft.Json;
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

        public async Task<LineUserInfo> GetUserInfoAsync(string LineUID)
        {
            var data = await lineHttpClient.GetProfileAsync(LineUID).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<LineUserInfo>(Encoding.UTF8.GetString(data));
        }
    }
}
