# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copy project file
COPY API.csproj .

# Restore dependencies
RUN dotnet restore

# Copy source code
COPY . .

# Build the application
RUN dotnet publish -c Release -o /app/publish


# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

# Copy published application
COPY --from=build /app/publish .

# Application listens on port 8080
EXPOSE 8080

# Start the API
ENTRYPOINT ["dotnet", "API.dll"]