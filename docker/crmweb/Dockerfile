# FROM microsoft/dotnet:2.1-sdk-alpine AS webbuild
FROM microsoft/dotnet:2.1-sdk AS webbuild
WORKDIR /app
COPY /tools/. ./tools/
RUN cp -rf ./tools/appsettings.default.json ./tools/appsettings.json
COPY /src/ThreeTrees.Metrics.sln ./src/ThreeTrees.Metrics.sln
COPY /src/ThreeTrees.Metrics.Services/ThreeTrees.Metrics.Services.csproj ./src/ThreeTrees.Metrics.Services/ThreeTrees.Metrics.Services.csproj
COPY /src/ThreeTrees.Metrics.Shared/ThreeTrees.Metrics.Shared.csproj ./src/ThreeTrees.Metrics.Shared/ThreeTrees.Metrics.Shared.csproj
COPY /src/ThreeTrees.Metrics.DataAccess/ThreeTrees.Metrics.DataAccess.csproj ./src/ThreeTrees.Metrics.DataAccess/ThreeTrees.Metrics.DataAccess.csproj
COPY /src/ThreeTrees.Metrics.Infrastructure/ThreeTrees.Metrics.Infrastructure.csproj ./src/ThreeTrees.Metrics.Infrastructure/ThreeTrees.Metrics.Infrastructure.csproj
COPY /src/ThreeTrees.Metrics.Domain/ThreeTrees.Metrics.Domain.csproj ./src/ThreeTrees.Metrics.Domain/ThreeTrees.Metrics.Domain.csproj
COPY /src/ThreeTrees.Metrics.Web/ThreeTrees.Metrics.Web.csproj ./src/ThreeTrees.Metrics.Web/ThreeTrees.Metrics.Web.csproj
WORKDIR /app/src/ThreeTrees.Metrics.Web
RUN dotnet restore
COPY /src/. /app/src/
RUN dotnet publish -c release -o bin/Release/netstandard2.0

# FIXME: Use alpine instead:
# FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS webruntime
# RUN apk add --no-cache gettext
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS webruntime
RUN apt-get update && apt-get install -y gettext-base
WORKDIR /app
COPY --from=webbuild /app/src/ThreeTrees.Metrics.Web/out ./