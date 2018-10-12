using System.Threading.Tasks;

namespace LineClient.AspNetCore.Messaging.Interfaces
{
    public interface ILineHttpClient
    {
        Task<byte[]> GetProfileAsync(string UID);
        Task<byte[]> GetRoomProfileAsync(string ChatRoomUID, string LineUID);
    }
}
