FROM mcr.microsoft.com/dotnet/sdk:9.0.100 AS build-env
WORKDIR /app

COPY backend.sln .
COPY API/*.csproj ./API/
COPY .env .
RUN dotnet restore

COPY API/ ./API/

# Modo Debug ya que se ejecutará en el ambiente local
RUN dotnet publish -c Debug -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0.1
WORKDIR /app
COPY --from=build-env /app/out .

# Puerto http
EXPOSE 80

ENTRYPOINT ["dotnet", "API.dll"]