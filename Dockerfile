FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["itl-gerenciador-usuarios-api.csproj", "itl-gerenciador-usuarios-api/"]
RUN dotnet restore "itl-gerenciador-usuarios-api.csproj"
COPY . .
WORKDIR "/src/itl-gerenciador-usuarios-api"
RUN dotnet build "itl-gerenciador-usuarios-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "itl-gerenciador-usuarios-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

USER root

COPY --from=publish /app/publish .

RUN mkdir -p /app/wwwroot/uploads \
    && chown -R $APP_UID:0 /app/wwwroot \
    && chmod -R 775 /app/wwwroot

USER $APP_UID

ENTRYPOINT ["dotnet", "itl-gerenciador-usuarios-api.dll"]
