# FK Teplice

## Informace
   K vývoji je používán [ASP.NET Core 2.0](https://www.microsoft.com/net/download) a [NMP](https://nodejs.org/en/) (instalován s Node.js)

***
## Databáze
V projektu je použiván [PostgreSQL](https://www.postgresql.org/). Connection string lze upravit v souboru `appsettings.json`.

***
## Spuštění


- Instalace závislostí
  - ```npm install```
- Build resourců
  - ```npm run build``` nebo  ```npm run watch```
- Spuštění migrací
  - ```dotnet ef database update```
- Spuštění projektu
  - ```dotnet run```
