var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    
    var html = @"
    <!DOCTYPE html>
    <html lang='pt-BR'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Meu Primeiro Site em C#</title>
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
                padding: 40px;
                background: white;
                border-radius: 20px;
                box-shadow: 0 20px 60px rgba(0,0,0,0.3);
                animation: fadeIn 1s ease-in;
            }
            
            @keyframes fadeIn {
                from {
                    opacity: 0;
                    transform: translateY(-20px);
                }
                to {
                    opacity: 1;
                    transform: translateY(0);
                }
            }
            
            h1 {
                color: #667eea;
                font-size: 3em;
                margin-bottom: 20px;
            }
            
            .highlight {
                background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
                color: white;
                padding: 10px 20px;
                border-radius: 50px;
                display: inline-block;
                font-size: 1.2em;
                margin: 20px 0;
            }
            
            .csharp-icon {
                font-size: 4em;
                margin: 20px 0;
            }
            
            .info {
                background: #f0f0f0;
                padding: 20px;
                border-radius: 10px;
                margin-top: 20px;
                text-align: left;
            }
            
            .info p {
                margin: 10px 0;
                color: #333;
            }
            
            .badge {
                display: inline-block;
                background: #28a745;
                color: white;
                padding: 5px 10px;
                border-radius: 5px;
                font-size: 0.8em;
                margin: 5px;
            }
            
            button {
                background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
                color: white;
                border: none;
                padding: 12px 30px;
                font-size: 1.1em;
                border-radius: 50px;
                cursor: pointer;
                margin-top: 20px;
                transition: transform 0.3s;
            }
            
            button:hover {
                transform: scale(1.05);
            }
            
            .datetime {
                color: #666;
                font-size: 0.9em;
                margin-top: 20px;
            }
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='csharp-icon'>💻</div>
            <h1>🌟 Este é meu primeiro site em C#! 🌟</h1>
            <div class='highlight'>C# + ASP.NET Core</div>
            
            <div class='info'>
                <p>✅ Site desenvolvido com C# e ASP.NET Core</p>
                <p>✅ Rode em qualquer lugar: Windows, Linux ou Docker</p>
                <p>✅ Super rápido e leve</p>
                <p>✅ Fácil de hospedar no Render, Heroku ou qualquer nuvem</p>
            </div>
            
            <div>
                <span class='badge'>C#</span>
                <span class='badge'>.NET 8</span>
                <span class='badge'>ASP.NET Core</span>
                <span class='badge'>Docker</span>
            </div>
            
            <button onclick='mostrarMensagem()'>Clique aqui!</button>
            
            <div class='datetime' id='datetime'></div>
        </div>
        
        <script>
            function mostrarMensagem() {
                alert('🎉 Parabéns! Seu primeiro site em C# está funcionando perfeitamente! 🎉');
            }
            
            function atualizarData() {
                const data = new Date();
                const dataFormatada = data.toLocaleString('pt-BR');
                document.getElementById('datetime').innerHTML = '📅 ' + dataFormatada;
            }
            
            atualizarData();
            setInterval(atualizarData, 1000);
        </script>
    </body>
    </html>
    ";
    
    await context.Response.WriteAsync(html);
});

app.MapGet("/sobre", async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    
    var html = @"
    <!DOCTYPE html>
    <html>
    <head>
        <meta charset='UTF-8'>
        <title>Sobre - Meu Primeiro Site em C#</title>
        <style>
            body {
                font-family: Arial, sans-serif;
                margin: 0;
                padding: 50px;
                background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            }
            .container {
                max-width: 800px;
                margin: 0 auto;
                background: white;
                padding: 40px;
                border-radius: 20px;
                box-shadow: 0 10px 40px rgba(0,0,0,0.2);
            }
            h1 { color: #667eea; }
            a {
                color: #667eea;
                text-decoration: none;
                display: inline-block;
                margin-top: 20px;
            }
            a:hover { text-decoration: underline; }
        </style>
    </head>
    <body>
        <div class='container'>
            <h1>Sobre este site</h1>
            <p>Este é um site simples desenvolvido em C# usando ASP.NET Core.</p>
            <p>O C# é uma linguagem de programação moderna, orientada a objetos e desenvolvida pela Microsoft.</p>
            <p>Com C# você pode criar:</p>
            <ul>
                <li>Aplicações web</li>
                <li>Aplicativos desktop</li>
                <li>Jogos com Unity</li>
                <li>Aplicativos mobile</li>
                <li>APIs e microsserviços</li>
            </ul>
            <a href='/'>← Voltar para página inicial</a>
        </div>
    </body>
    </html>
    ";
    
    await context.Response.WriteAsync(html);
});

app.Run();
