FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar apenas o csproj primeiro
COPY MeuPrimeiroSite.csproj .
RUN dotnet restore

# Copiar o resto
COPY . .

# Compilar e publicar
RUN dotnet publish -c Release -o out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Instalar curl para healthcheck
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

# Copiar os arquivos publicados
COPY --from=build /app/out .

# Configurar porta
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Verificar saúde da aplicação
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost/ || exit 1

# Iniciar
ENTRYPOINT ["dotnet", "MeuPrimeiroSite.dll"]
