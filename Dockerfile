# ETAPA 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY WebEmpresa.csproj ./
RUN dotnet restore WebEmpresa.csproj

COPY . ./

RUN dotnet publish WebEmpresa.csproj \
    -c Release \
    -o /app/publish \
    --no-restore


# ETAPA 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 8080

ENTRYPOINT ["dotnet", "WebEmpresa.dll"]