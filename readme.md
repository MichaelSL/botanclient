# Yandex Metrica Botan client

Yandex Metrica Botan client for .NET
`NETStandard 2.0`

[![Build status](https://ci.appveyor.com/api/projects/status/0feuu0fmae9917p1/branch/master?svg=true)](https://ci.appveyor.com/project/MichaelSL/botanclient/branch/master)

## Usage

### Reference `BotanClient`

Install via NuGet:

```PM> Install-Package BotanClient```

or build the NuGet with Cake build:
```powershell
./build.ps1 -target "BotanClient"
```

### Modify your project code

Register client in your services and provide your yandex metrica token:

```csharp
services.AddSingleton(_ => new BotanClient.BotanClient(botanToken));
```

Inject client into your controller:

```csharp
private readonly BotanClient.BotanClient botanClient;

public UpdateController(BotanClient.BotanClient botanClient)
{
    this.botanClient = botanClient;
}
```

Send data to Botan:

```csharp
await botanClient.SendEvent(new BotanMessage
{
    EventName = "MY_EVENT",
    RawData = new {
        message = message,
        someMetric = 1.0
    },
    Uid = "UserIdHere"
});
```