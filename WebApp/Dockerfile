# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["WebApp.csproj", "./"]

RUN dotnet restore "WebApp.csproj"

COPY . .

RUN dotnet publish "WebApp.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WebApp.dll"]
