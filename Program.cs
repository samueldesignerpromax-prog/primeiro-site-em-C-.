var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Content("""
<!DOCTYPE html>
<html>
<head>
    <title>Meu Primeiro Site em C#</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .container {
            text-align: center;
            background: white;
            padding: 40px;
            border-radius: 20px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);
            max-width: 90%;
            width: 500px;
        }
        h1 {
            color: #667eea;
            font-size: 2em;
            margin: 20px 0;
        }
        .emoji {
            font-size: 4em;
        }
        .badge {
            background: #667eea;
            color: white;
            padding: 8px 20px;
            border-radius: 50px;
            display: inline-block;
            margin: 20px 0;
        }
        .info {
            background: #f0f0f0;
            padding: 15px;
            border-radius: 10px;
            margin: 20px 0;
            text-align: left;
        }
        button {
            background: #667eea;
            color: white;
            border: none;
            padding: 10px 30px;
            border-radius: 50px;
            font-size: 1em;
            cursor: pointer;
            margin: 10px 0;
        }
        button:hover {
            background: #764ba2;
        }
        a {
            color: #667eea;
            text-decoration: none;
            display: inline-block;
            margin: 10px;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="emoji">🚀</div>
        <h1>🌟 Este é meu primeiro site em C#! 🌟</h1>
        <div class="badge">C# + ASP.NET Core</div>
        <div class="info">
            <p>✅ Site funcionando perfeitamente!</p>
            <p>✅ Desenvolvido com C# e .NET 8</p>
            <p>✅ Rodando em container Docker</p>
            <p>✅ Hospedado no Render</p>
        </div>
        <button onclick="alert('Parabéns! Site em C# funcionando! 🎉')">Clique aqui</button>
        <br>
        <a href="/sobre">Sobre este projeto</a>
    </div>
</body>
</html>
""", "text/html"));

app.MapGet("/sobre", () => Results.Content("""
<!DOCTYPE html>
<html>
<head>
    <title>Sobre - Meu Primeiro Site</title>
    <meta charset="UTF-8">
    <style>
        body {
            margin: 0;
            padding: 20px;
            font-family: Arial, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
        }
        .container {
            max-width: 800px;
            margin: 0 auto;
            background: white;
            padding: 30px;
            border-radius: 20px;
        }
        h1 { color: #667eea; }
        a {
            color: #667eea;
            text-decoration: none;
            display: inline-block;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>Sobre este site</h1>
        <p>Este é um site simples criado com C# e ASP.NET Core.</p>
        <p>C# é uma linguagem de programação moderna desenvolvida pela Microsoft.</p>
        <h3>Tecnologias usadas:</h3>
        <ul>
            <li>C# 12</li>
            <li>.NET 8</li>
            <li>ASP.NET Core</li>
            <li>Docker</li>
        </ul>
        <a href="/">← Voltar</a>
    </div>
</body>
</html>
""", "text/html"));

app.Run();
