# Usando a imagem base do ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Usando a imagem do SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copiando o arquivo .csproj para o contêiner
COPY ["store.api/store.api.csproj", "."]

# Verificando se o arquivo .csproj está presente
RUN ls -la

# Restaurando as dependências
RUN dotnet restore "./store.api.csproj"

# Copiando o restante do código
COPY . .

# Realizando o build
WORKDIR "/src/."
RUN dotnet build "./store.api.csproj" -c Release -o /app/build -v diag

# Publicando a aplicação
FROM build AS publish
RUN dotnet publish "./store.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Definindo o contêiner final
FROM base AS final
WORKDIR /app

# Copiando o binário publicado
COPY --from=publish /app/publish .

# Definindo o entry point
ENTRYPOINT ["dotnet", "store.api.dll"]
