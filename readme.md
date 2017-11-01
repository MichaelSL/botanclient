# Yandex Metrica Botan client

Yandex Metrica Botan client for .NET
`NETStandard 2.0`

## Usage

Reference `BotanClient`.

Register client in your services and provide your yandex metrica token:
`services.AddSingleton(_ => new BotanClient.BotanClient(botanToken));`
