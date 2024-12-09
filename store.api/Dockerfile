# Usando a imagem base do ASP.NET para a execução da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Usando a imagem do SDK do .NET para a construção
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copiando o arquivo .csproj para o contêiner
COPY ["store.api/store.api.csproj", "./store.api/"]

# Verificando se o arquivo .csproj foi copiado corretamente (útil para depuração)
RUN ls -la ./store.api

# Restaurando as dependências do projeto
RUN dotnet restore "./store.api/store.api.csproj"

# Copiando o restante do código para o contêiner
COPY . .

# Realizando a construção do projeto em modo Release
RUN dotnet build "./store.api/store.api.csproj" -c Release -o /app/build -v diag

# Publicando a aplicação para a pasta /app/publish
FROM build AS publish
RUN dotnet publish "./store.api/store.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem base para rodar a aplicação
FROM base AS final
WORKDIR /app

# Copiando o binário publicado da etapa de build para o contêiner final
COPY --from=publish /app/publish .

# Definindo o ponto de entrada para rodar a aplicação
ENTRYPOINT ["dotnet", "store.api.dll"]
