FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS publish
ARG arch=linux-x64
RUN apt-get update && apt-get -y install clang zlib1g-dev libkrb5-dev libtinfo5
WORKDIR /src
COPY ["nuget.config", ""]
COPY ["CLIExample.csproj", ""]
RUN dotnet restore -r $arch "./CLIExample.csproj"
COPY . .
RUN dotnet publish "CLIExample.csproj" --no-restore -r $arch -c Release -o /app/publish /p:InvariantGlobalization=true

FROM debian:buster-slim as final
WORKDIR /app
COPY --from=publish /app/publish/CLIExample ./CLIExample
ENTRYPOINT ["./CLIExample"]