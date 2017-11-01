# Yandex Metrica Botan client

Yandex Metrica Botan client for .NET
`NETStandard 2.0`

[![Build status](https://ci.appveyor.com/api/projects/status/0feuu0fmae9917p1/branch/master?svg=true)](https://ci.appveyor.com/project/MichaelSL/botanclient/branch/master)

## Usage

Reference `BotanClient`.

Register client in your services and provide your yandex metrica token:
`services.AddSingleton(_ => new BotanClient.BotanClient(botanToken));`
