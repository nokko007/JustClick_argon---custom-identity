FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["JustClick/JustClick.csproj", "JustClick/"]
RUN dotnet restore "JustClick/JustClick.csproj"
COPY . .
WORKDIR "/src/JustClick"
RUN dotnet build "JustClick.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JustClick.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JustClick.dll"]
