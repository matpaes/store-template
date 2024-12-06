FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["store.api/store.api.csproj", "."]

RUN dotnet restore "./store.api.csproj"

COPY . .

WORKDIR "/src/."
RUN dotnet build "store.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "store.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "store.api.dll"]
