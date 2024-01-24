#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend/Company.Api/Company.Api.csproj", "Backend/Company.Api/"]
COPY ["Backend/Company.Core/Company.Core.csproj", "Backend/Company.Core/"]
COPY ["Backend/Company.Data/Company.Data.csproj", "Backend/Company.Data/"]
RUN dotnet restore "./Backend/Company.Api/./Company.Api.csproj"
COPY . .
WORKDIR "/src/Backend/Company.Api"
RUN dotnet build "./Company.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Company.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.Api.dll"]