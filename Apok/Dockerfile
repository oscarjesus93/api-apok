# Usamos la imagen base de .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos el archivo .csproj y restauramos las dependencias
COPY ["Api/Api.csproj", "Api/"]
RUN dotnet restore "Api/Api.csproj"

# Copiamos el resto del código fuente
COPY . .

# Construimos la aplicación
RUN dotnet build "Api/Api.csproj" -c Release -o /app/build

# Publicamos la aplicación
RUN dotnet publish "Api/Api.csproj" -c Release -o /app/publish

# Usamos la imagen base para ejecutar la API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Api.dll"]
