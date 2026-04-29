var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync(@"
        <!DOCTYPE html>
        <html>
        <head>
            <title>Meu Primeiro Site em C#</title>
            <style>
                body { 
                    text-align: center; 
                    font-family: Arial; 
                    margin-top: 50px;
                    background: linear-gradient(45deg, #FF6B6B, #4ECDC4);
                    color: white;
                }
                h1 { font-size: 3em; }
                .box {
                    background: white;
                    color: black;
                    padding: 30px;
                    border-radius: 10px;
                    margin: 20px auto;
                    width: 80%;
                    max-width: 600px;
                }
            </style>
        </head>
        <body>
            <h1>🎉 Este é meu primeiro site em C#! 🎉</h1>
            <div class='box'>
                <h2>Olá, mundo!</h2>
                <p>Estou programando em C# e este site está rodando perfeitamente!</p>
                <p>Servidor: ASP.NET Core</p>
                <p>Data e hora: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + @"</p>
            </div>
        </body>
        </html>
    ");
});

app.Run();
