#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ftl.Backoffice.API/Ftl.Backoffice.API.csproj", "Ftl.Backoffice.API/"]
COPY ["Ftl.Backoffice.Application/Ftl.Backoffice.Application.csproj", "Ftl.Backoffice.Application/"]
COPY ["Ftl.Backoffice.DataAccess/Ftl.Backoffice.DataAccess.csproj", "Ftl.Backoffice.DataAccess/"]
COPY ["Ftl.Backoffice.Data/Ftl.Backoffice.Core.csproj", "Ftl.Backoffice.Data/"]
COPY ["Ftl.Backoffice.Shared/Ftl.Backoffice.Shared.csproj", "Ftl.Backoffice.Shared/"]
RUN dotnet restore "Ftl.Backoffice.API/Ftl.Backoffice.API.csproj"
COPY . .
WORKDIR "/src/Ftl.Backoffice.API"
RUN dotnet build "Ftl.Backoffice.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ftl.Backoffice.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ftl.Backoffice.API.dll"]