FROM ubuntu:20.04 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
RUN apt-get update && apt-get -y install clang zlib1g-dev libkrb5-dev libtinfo5
WORKDIR /src
COPY ["nuget.config", ""]
COPY ["CLIExample.csproj", ""]
RUN dotnet restore "./CLIExample.csproj"
COPY . .
RUN dotnet build "CLIExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CLIExample.csproj" -r linux-x64 -c Release -o /app/publish /p:InvariantGlobalization=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/CLIExample ./CLIExample
ENTRYPOINT ["./CLIExample"]