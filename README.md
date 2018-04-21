# FK Teplice

## Informace
   K vývoji je používán [ASP.NET Core 2.0](https://www.microsoft.com/net/download) a [NMP](https://nodejs.org/en/) (instalován s Node.js)

***
## Databáze
V projektu je použiván [PostgreSQL](https://www.postgresql.org/). Connection string lze upravit v souboru `appsettings.json`.

#### Seedování
V projektu je implementováno vlastní seedování databáze. Vlastní seeder musí implementovat rozhraní `ISeeder` a pro hromadné spuštění musí být zaregistrován v `Data/ApplicationDbSeeder.cs`.

Hromadné seedování (spuštění všech zaregistrovaných seederů) se spustí příkazem `dotnet run seed`.
Jednotlivé seedery lze spustit příkazem `dotnet run seed --[název seederu]` (nutné uvádět i jmenný prostor).

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
