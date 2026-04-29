FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar arquivo do projeto
COPY *.csproj ./
RUN dotnet restore

# Copiar o resto e publicar
COPY . ./
RUN dotnet publish -c Release -o out

# Imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "MeuPrimeiroSite.dll"]
