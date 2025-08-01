# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY CarCenter.sln .
COPY CarCenter/CarCenter.csproj CarCenter/

RUN dotnet restore

COPY CarCenter/. ./CarCenter/
WORKDIR /src/CarCenter

RUN dotnet publish -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CarCenter.dll"]