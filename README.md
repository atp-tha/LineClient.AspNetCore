


LineClient.AspNetCore
============

LINE Developers' API Client for .NET Core.

Library created for .NET Core implementation based on [LINE Developer's documentation](https://developers.line.me/en/) .

##  LineClient.AspNetCore.Messaging
A package to utilize [LINE Messaging API](https://developers.line.me/en/services/messaging-api/) .
### How to use
Add this to your project's Startup.cs to enable injection of `ILineMessagingClient`.

```
  services.AddLineMessagingClient("CHANNEL_ACCESS_TOKEN_HERE");
```

Then you're able to inject `ILineMessagingClient` to anything using .NET Core's built in Dependency Injection.

```
public SampleClass(ILineMessagingClient lineMessagingClient)
{
    //iniializations
}
```
Example:
```
[HttpGet("{id}")]
public async Task<ActionResult<string>> Get([FromServices] ILineMessagingClient lineMessagingClient)
{
    var message = new LineTextMessage()
    {
        //message properties here
    };
    var chatroom = await lineMessagingClient.GetChatRoomInfoAsync("roomId");

    lineMessagingClient.PushMessageAsync(message, chatroom);

    return "value";
}
```
## Contributing
Getting started by [logging in](https://developers.line.me/console/) to your LINE account and enable developer mode. Get your access token and start hacking!

Every project in the solution has its own README.md. Navigate to those folders to read about intended architecture and function.
* [LineClient.AspNetCore.Messaging](https://github.com/beam-codegrind/LineClient.AspNetCore/tree/master/src/LineClient.AspNetCore.Messaging) - Messaging API
