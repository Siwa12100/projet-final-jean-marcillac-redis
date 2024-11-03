#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["projet-jean-marcillac/projet-jean-marcillac.csproj", "projet-jean-marcillac/"]
RUN dotnet restore "./projet-jean-marcillac/projet-jean-marcillac.csproj"
COPY . .
WORKDIR "/src/projet-jean-marcillac"
RUN dotnet build "./projet-jean-marcillac.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./projet-jean-marcillac.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "projet-jean-marcillac.dll"]
ENTRYPOINT ["dotnet", "projet-jean-marcillac.dll", "--urls", "http://0.0.0.0:80"]
