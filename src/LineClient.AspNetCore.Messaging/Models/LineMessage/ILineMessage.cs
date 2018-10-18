using System.Net.Http;

namespace LineClient.AspNetCore.Messaging.Models.LineMessage
{
    public interface ILineMessage
    {
        StringContent GenerateStringContent();
    }
}
