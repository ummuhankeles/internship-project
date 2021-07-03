FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY ./Server.Data ./Server.Data
COPY ./Server.Models ./Server.Models
COPY ./Server.Service ./Server.Service
COPY ./Server.WebAPI ./Server.WebAPI
RUN dotnet publish ./Server.WebAPI/Server.WebAPI.csproj -c Release -o /app --no-cache /restore


FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Server.WebAPI.dll"]