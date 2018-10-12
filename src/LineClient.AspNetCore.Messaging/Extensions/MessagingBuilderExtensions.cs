using LineClient.AspNetCore.Messaging.Implements;
using LineClient.AspNetCore.Messaging.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LineClient.AspNetCore.Messaging.Extensions
{
    public static class MessagingBuilderExtensions
    {
        public static void AddLineMessagincClient(this IServiceCollection services, string channelAccessToken)
        {
            services.AddHttpClient<ILineHttpClient,LineHttpClient>(client => new LineHttpClient(client, channelAccessToken));
        }
    }
}
