FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["YourApiProject/YourApiProject.csproj", "YourApiProject/"]
RUN dotnet restore "YourApiProject/YourApiProject.csproj"
COPY . .
WORKDIR "/src/YourApiProject"
RUN dotnet build "YourApiProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YourApiProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YourApiProject.dll"]
