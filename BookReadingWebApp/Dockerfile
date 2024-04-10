#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookReadingWebApp/BookReadingApp.Web.csproj", "BookReadingWebApp/"]
COPY ["BookReadingApp.Application/BookReadingApp.Application.csproj", "BookReadingApp.Application/"]
COPY ["BookReadingApp.Core/BookReadingApp.Core.csproj", "BookReadingApp.Core/"]
COPY ["BookReadingApp.Infrastructure/BookReadingApp.Infrastructure.csproj", "BookReadingApp.Infrastructure/"]
RUN dotnet restore "BookReadingWebApp/BookReadingApp.Web.csproj"
COPY . .


# WORKDIR "/src/BookReadingWebApp"
# RUN dotnet build "BookReadingApp.Web.csproj" -c Release -o /app/build

# FROM build AS publish
RUN dotnet publish "BookReadingApp.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false
WORKDIR "/src"
RUN dotnet test "BookReadingApp.Tests/BookReadingApp.Tests.csproj" --logger "trx;LogFileName=./aspnetapp.trx"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookReadingApp.Web.dll"]