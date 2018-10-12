LineClient.AspNetCore
============

LINE Developers' API Client for .NET Core.

Library created for .NET Core implementation based on LINE Developer's documentation (https://developers.line.me/en/).

Not just for emails. Also good for ensuring clean, dependency free content from CMSs and the like.

This was created a long time ago as an alternative to Premailer.Net (which doesn't work properly!) to solve an actual business need. As of writing, it has been running in production, cleansing hundreds of emails per month, for the last few years. Just got around to open sourcing it :)


## APIs


### LineClient.AspNetCore.Messaging
Add this to your project's Startup.cs to start enable injection of ```ILineMessagingClient```.

```
  services.AddLineMessagincClient("CHANNEL_ACCESS_TOKEN_HERE");
```
Then you're able to inject ```ILineMessagingClient``` to anything using .NET Core's built in Dependency Injection.

Args:
* Coming Soon !

What it does: 
* Coming Soon !


## Contributing

Will be updated with architecture and getting started.
