using LineClient.AspNetCore.Messaging.Interfaces;
using LineClient.AspNetCore.Messaging.Models.LineMessage.Implements;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Controllers.Messaging
{
    [Route("api/Messaging/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly ILineMessagingClient lineMessagingClient;

        public ChatRoomController (ILineMessagingClient lineMessagingClient)
        {
            this.lineMessagingClient = lineMessagingClient;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(string toLineUserId, string message, string userId)
        {
            var lineMessage = new LineTextMessage(toLineUserId, message);
            var userInfo = await lineMessagingClient.GetUserInfoAsync(userId);
            string returndata = await lineMessagingClient.PushMessageAsync(lineMessage, userInfo);
            return returndata;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
