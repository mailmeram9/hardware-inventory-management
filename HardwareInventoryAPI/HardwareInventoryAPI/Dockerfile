# Use official .NET 9 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage with SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy everything into the container
COPY . .

# Restore dependencies
RUN dotnet restore "HardwareInventoryAPI.csproj"

# Build the project
RUN dotnet build "HardwareInventoryAPI.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "HardwareInventoryAPI.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Run the app
ENTRYPOINT ["dotnet", "HardwareInventoryAPI.dll"]
