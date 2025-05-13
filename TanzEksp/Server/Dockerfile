# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 9597


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TanzEksp/Server/TanzEksp.Server.csproj", "TanzEksp/Server/"]
COPY ["TanzEksp.Application/TanzEksp.Application.csproj", "TanzEksp.Application/"]
COPY ["TanzEksp.Infrastructure/TanzEksp.Domain.csproj", "TanzEksp.Infrastructure/"]
COPY ["TanzEksp.Persistence/TanzEksp.Infrastructure.csproj", "TanzEksp.Persistence/"]
COPY ["TanzEksp/Client/TanzEksp.Client.csproj", "TanzEksp/Client/"]
COPY ["TanzEksp/Shared/TanzEksp.Shared.csproj", "TanzEksp/Shared/"]
RUN dotnet restore "./TanzEksp/Server/TanzEksp.Server.csproj"
COPY . .
WORKDIR "/src/TanzEksp/Server"
RUN dotnet build "./TanzEksp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TanzEksp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TanzEksp.Server.dll"]