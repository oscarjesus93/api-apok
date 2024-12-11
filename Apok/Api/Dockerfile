# Usamos la imagen base de .NET 8 SDK
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Usamos la imagen de desarrollo de .NET para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Api.csproj", "./"]
RUN dotnet restore "./Api.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "./Api.csproj" -c Release -o /app/build

# Publicamos la aplicación
FROM build AS publish
RUN dotnet publish "./Api.csproj" -c Release -o /app/publish

# Usamos la imagen base para ejecutar la API
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
