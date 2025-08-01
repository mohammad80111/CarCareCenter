COPY CarCenter.sln .
COPY CarCenter/CarCenter.csproj ./CarCenter/

RUN dotnet restore

COPY CarCenter/. ./CarCenter/
WORKDIR /app/CarCenter

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CarCenter.dll"]