# Use the official ASP.NET runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the .csproj files for both projects and restore packages
COPY ["ClothesShop.API/ClothesShop.API.csproj", "ClothesShop.API/"]
COPY ["ClothesShop.Infrastructure/ClothesShop.Infrastructure.csproj", "ClothesShop.Infrastructure/"]
RUN dotnet restore "ClothesShop.API/ClothesShop.API.csproj"
RUN dotnet restore "ClothesShop.Infrastructure/ClothesShop.Infrastructure.csproj"

# Copy the rest of the application code and build the API project
COPY . .
WORKDIR "/src/ClothesShop.API"
RUN dotnet build "ClothesShop.API.csproj" -c Release -o /app/build

# Publish the API project
FROM build AS publish
RUN dotnet publish "ClothesShop.API.csproj" -c Release -o /app/publish

# Build the final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClothesShop.API.dll"]
