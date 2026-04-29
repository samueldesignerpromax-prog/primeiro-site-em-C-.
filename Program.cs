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
            animation: fadeIn 0.5s ease-in;
        }
        @keyframes fadeIn {
            from { opacity: 0; transform: translateY(-20px); }
            to { opacity: 1; transform: translateY(0); }
        }
        h1 {
            color: #667eea;
            font-size: 2.5em;
            margin-bottom: 20px;
        }
        .emoji {
            font-size: 4em;
            margin-bottom: 20px;
        }
        .badge {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 10px 20px;
            border-radius: 50px;
            display: inline-block;
            margin: 20px 0;
            font-weight: bold;
        }
        .info {
            background: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            margin: 20px 0;
            text-align: left;
        }
        .info p {
            margin: 10px 0;
            color: #333;
        }
        button {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            border: none;
            padding: 12px 30px;
            border-radius: 50px;
            font-size: 1.1em;
            cursor: pointer;
            transition: transform 0.3s;
            margin-top: 10px;
        }
        button:hover {
            transform: scale(1.05);
        }
        .footer {
            margin-top: 20px;
            color: #666;
            font-size: 0.9em;
        }
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
        
        <button onclick='mostrarMensagem()'>Clique para celebrar! 🎉</button>
        
        <div class='footer'>
            <p>Tecnologias: C# 12 | .NET 8 | ASP.NET Core</p>
        </div>
    </div>
    
    <script>
        function mostrarMensagem() {
            alert('🎉 Parabéns! Seu primeiro site em C# está funcionando perfeitamente! 🎉');
        }
    </script>
</body>
</html>
    ");
});

app.MapGet("/sobre", async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    
    await context.Response.WriteAsync(@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <title>Sobre - Meu Primeiro Site em C#</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 50px;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
        }
        .container {
            max-width: 800px;
            margin: 0 auto;
            background: white;
            padding: 40px;
            border-radius: 20px;
            box-shadow: 0 10px 40px rgba(0,0,0,0.2);
        }
        h1 { color: #667eea; margin-bottom: 20px; }
        a {
            color: #667eea;
            text-decoration: none;
            display: inline-block;
            margin-top: 20px;
            padding: 10px 20px;
            background: #f0f0f0;
            border-radius: 5px;
        }
        a:hover { background: #e0e0e0; }
        ul { margin: 20px 0; padding-left: 20px; }
        li { margin: 10px 0; }
    </style>
</head>
<body>
    <div class='container'>
        <h1>Sobre este site</h1>
        <p>Este é um site simples desenvolvido em C# usando ASP.NET Core, especialmente criado para demonstrar como é fácil criar aplicações web com Microsoft technologies.</p>
        
        <h2>O que é C#?</h2>
        <p>C# é uma linguagem de programação moderna, orientada a objetos e desenvolvida pela Microsoft. É uma das linguagens mais populares do mundo!</p>
        
        <h2>Com C# você pode criar:</h2>
        <ul>
            <li>🌐 Aplicações web (como este site)</li>
            <li>📱 Aplicativos mobile com .NET MAUI</li>
            <li>🎮 Jogos com Unity</li>
            <li>⚙️ APIs e microsserviços</li>
            <li>💻 Aplicações desktop</li>
        </ul>
        
        <a href='/'>← Voltar para página inicial</a>
    </div>
</body>
</html>
    ");
});

app.Run();
