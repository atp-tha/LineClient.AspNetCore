using FakeItEasy;
using LineClient.AspNetCore.Messaging.Implements;
using LineClient.AspNetCore.Messaging.Interfaces;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LineClient.AspNetCore.Messaging.Test.LineMessagingClientTests
{
    public class GetUserInfoAsyncMethod
    {
        [Fact(DisplayName = "GetUserInfoAsyncMethod : ReturnUserInfoIfValidDataReturnedFromApi")]
        public async Task ReturnUserInfoIfValidDataReturnedFromApi()
        {
            // Arrange
            // Mock Dependencies
            ILineHttpClient fakeLineHttpClient = A.Fake<ILineHttpClient>();

            //Initialize
            ILineMessagingClient realLineMessagingClient = new LineMessagingClient(fakeLineHttpClient);

            //Mock Data
            string fakeResponseData = @"{
                ""displayName"" : ""user"",
                ""userId"" : ""test"",
                ""pictureUrl"" : ""img"",
                ""statusMessage"" : ""busy"",
            }";
            byte[] fakeResponse = Encoding.ASCII.GetBytes(fakeResponseData);
            A.CallTo(() => fakeLineHttpClient.GetProfileAsync("test")).Returns(Task.FromResult(fakeResponse));

            // Act
            var testResult = await realLineMessagingClient.GetUserInfoAsync("test");

            // Assert
            A.CallTo(() => fakeLineHttpClient.GetProfileAsync("test")).MustHaveHappened();
            Assert.Equal("user", testResult.displayName);
            Assert.Equal("test", testResult.userId);
            Assert.Equal("img", testResult.pictureUrl);
            Assert.Equal("busy", testResult.statusMessage);
        }
    }
}
