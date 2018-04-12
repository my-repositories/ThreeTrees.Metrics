# CRM Metrics
## ThreeTrees Inc.

---
---

### Instructions for Windows

* Install .NET Core
[https://www.microsoft.com/net/learn/get-started/windows](https://www.microsoft.com/net/learn/get-started/windows)

---

* Go to the Package Manager Console
* Select default project ThreeTrees.Metrics.DataAccess
* Run this command

```sh
Update-Database
```

---

* Copy default appsettings

```sh
copy ./tools/appsettings.default.json ./tools/appsettings.json
```

---
---

### Instructions for Linux/Mac

* Install .NET Core
[https://www.microsoft.com/net/learn/get-started/linuxubuntu](https://www.microsoft.com/net/learn/get-started/linuxubuntu)

---

* Configure

```sh
(cd ./src/ThreeTrees.Metrics.DataAccess && dotnet add package Microsoft.EntityFrameworkCore.Design)
(cd ./src/ThreeTrees.Metrics.DataAccess && dotnet add package Microsoft.EntityFrameworkCore.Tools)
(cd ./src/ThreeTrees.Metrics.DataAccess && dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet)

(cd ./src/ThreeTrees.Metrics.DataAccess && dotnet restore)
(cd ./src/ThreeTrees.Metrics.DataAccess && dotnet ef database update)
```

---

* Build

```sh
cp ./tools/appsettings.default.json ./tools/appsettings.json
dotnet build ./src/ThreeTrees.Metrics.Web/ThreeTrees.Metrics.Web.csproj -c Release
```

---

* Startup

```sh
(cd ./src/ThreeTrees.Metrics.Web/bin/Release/netcoreapp2.0 && dotnet ThreeTrees.Metrics.Web.dll)
```