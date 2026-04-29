#!/bin/bash

# Remover arquivos conflitantes
rm -f ProgramaSuperSimples.cs
rm -f ProgramaSimples.cs
rm -f Program.cs.bak

# Garantir que apenas o Program.cs correto existe
cat > Program.cs << 'EOF'
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    
    await context.Response.WriteAsync(@"
<!DOCTYPE html>
<html lang='pt-BR'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Meu Primeiro Site em C#</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 20px;
        }
        .container {
            background: white;
            border-radius: 20px;
            padding: 50px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);
            text-align: center;
            max-width: 600px;
        }
        h1 { color: #667eea; font-size: 2.5em; margin-bottom: 20px; }
        .emoji { font-size: 4em; margin-bottom: 20px; }
        .badge {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 10px 20px;
            border-radius: 50px;
            display: inline-block;
            margin: 20px 0;
        }
        .info {
            background: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            margin: 20px 0;
            text-align: left;
        }
        button {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            border: none;
            padding: 12px 30px;
            border-radius: 50px;
            font-size: 1.1em;
            cursor: pointer;
        }
        button:hover { transform: scale(1.05); }
    </style>
</head>
<body>
    <div class='container'>
        <div class='emoji'>🚀</div>
        <h1>🌟 Este é meu primeiro site em C#! 🌟</h1>
        <div class='badge'>C# + ASP.NET Core</div>
        <div class='info'>
            <p>✅ Site desenvolvido com sucesso em C#</p>
            <p>✅ Rodando em Docker container</p>
            <p>✅ Hospedado no Render.com</p>
            <p>✅ Data e hora: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + @"</p>
        </div>
        <button onclick='alert(\"🎉 Parabéns! Seu primeiro site em C# está funcionando! 🎉\")'>Clique para celebrar! 🎉</button>
    </div>
</body>
</html>
    ");
});

app.Run();
EOF

# Atualizar Dockerfile
cat > Dockerfile << 'EOF'
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "MeuPrimeiroSite.dll"]
EOF

echo "Repositório corrigido! Agora faça commit e push:"
echo "git add ."
echo "git commit -m 'Fix build error - single Program.cs file'"
echo "git push origin main"
