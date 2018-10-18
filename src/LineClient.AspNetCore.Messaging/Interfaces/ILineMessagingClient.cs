using LineClient.AspNetCore.Messaging.Models;
using LineClient.AspNetCore.Messaging.Models.LineMessage;
using System.Threading.Tasks;

namespace LineClient.AspNetCore.Messaging.Interfaces
{
    public interface ILineMessagingClient
    {
        Task<LineUserInfo> GetUserInfoAsync(string LineUID);
        Task<LineChatRoomInfo> GetChatRoomInfoAsync(string ChatRoomUID);
        Task<string> PushMessageAsync(ILineMessage lineMessage, LineUserInfo userInfo);
        Task PushMessageAsync(ILineMessage lineMessage, LineChatRoomInfo chatRoomInfo);
    }
}
