#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/OnlineSocial/src/OnlineSocial.WebApi/OnlineSocial.WebApi.csproj", "src/OnlineSocial/src/OnlineSocial.WebApi/"]
COPY ["src/OnlineSocial/src/OnlineSocial.Foundation/OnlineSocial.Foundation.csproj", "src/OnlineSocial/src/OnlineSocial.Foundation/"]
RUN dotnet restore "src/OnlineSocial/src/OnlineSocial.WebApi/OnlineSocial.WebApi.csproj"
COPY . .
WORKDIR "/src/src/OnlineSocial/src/OnlineSocial.WebApi"
RUN dotnet build "OnlineSocial.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineSocial.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineSocial.WebApi.dll"]