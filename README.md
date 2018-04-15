# FK Teplice

## Informace
   K vývoji je používán [ASP.NET Core 2.0](https://www.microsoft.com/net/download) a [NMP](https://nodejs.org/en/) (instalován s Node.js)

***
## Databáze
Defaultně je v ASP.NET Core 2.0 používán SQLite. Kvůli jeho omezením je nutné před spuštěním migrací zakomentovat `migrationBuilder.AddForeignKey` a `migrationBuilder.DropForeignKey` v `_InitialMigration.cs`.  
Typ databáze se nastavuje v souboru `Startup.cs` (nutné nainstalovat providery) a connection string v souboru `appsettings.json`.

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
