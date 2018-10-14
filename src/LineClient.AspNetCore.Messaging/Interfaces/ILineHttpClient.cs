using System.Threading.Tasks;

namespace LineClient.AspNetCore.Messaging.Interfaces
{
    public interface ILineHttpClient
    {
        Task<byte[]> GetProfileAsync(string userId);
        Task<byte[]> GetRoomProfileAsync(string roomId, string userId);
    }
}
