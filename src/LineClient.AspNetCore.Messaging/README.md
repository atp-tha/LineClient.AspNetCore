



LineClient.AspNetCore.Messaging
============
Library created for .NET Core implementation based on [LINE Messaging API's documentation ](https://developers.line.me/en/services/messaging-api/).

## MessagingBuilderExtensions

Add this to your project's Startup.cs to enable injection of ```ILineMessagingClient```.

```
  services.AddLineMessagingClient("CHANNEL_ACCESS_TOKEN_HERE");
```
Then you're able to inject ```ILineMessagingClient``` to anything using .NET Core's built in Dependency Injection.

## LineHttpClient
This class extends upon ```HttpClientFactory``` typed client implementation. All LINE Messaging API endpoints should be described in this class.
## LineMessagingClient
This class has three main functions:
* GetUserInfoAsync - Return ```LineUserInfo``` of a user using user's ID.
* GetChatRoomInfoAsync - Return ```LineChatRoomInfo``` of a chat room using room's ID.
* PushMessageAsync has 2 overloads:
	* Push an ```ILineMessage``` to a user using ```LineUserInfo```
	* Push an ```ILineMessage``` to a chat room using ```LineChatRoomInfo```

Web API Example:
```
[HttpGet("{id}")]
public async Task<ActionResult<string>> Get([FromServices] ILineMessagingClient lineMessagingClient)
{
    var message = new LineMessageText()
    {
        //message properties here
    };
    var chatroom = await lineMessagingClient.GetChatRoomInfoAsync("roomId");

    lineMessagingClient.PushMessageAsync(message, chatroom);

    return "value";
}
```
## ILineMessage
An interface for any LINE message with various types of LINE message which have their own ```GenerateStringContent``` implementation.

The method ```GenerateStringContent``` should generate string content exactly like [LINE Bot Designer](https://developers.line.me/en/services/bot-designer/).
## Naming Conventions
### Parameters
Name should be based from [LINE Messaging API](https://developers.line.me/en/reference/messaging-api/) and follow [Microsoft's guidline](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods)
