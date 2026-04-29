FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar arquivo do projeto
COPY *.csproj ./
RUN dotnet restore

# Copiar todos os arquivos
COPY . ./

# Publicar a aplicação
RUN dotnet publish -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=build /app/out .

# Configurar porta
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Healthcheck
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost/ || exit 1

# Iniciar aplicação
ENTRYPOINT ["dotnet", "MeuPrimeiroSite.dll"]
