using Crip_117.Interfaces;
using Crip_117.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicione servi�os ao cont�iner de inje��o de depend�ncia.
builder.Services.AddControllers();

// Configure o Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servi�o de criptografia
builder.Services.AddTransient<ICryptographyService, CryptographyService>();

var app = builder.Build();

// Configure o pipeline de solicita��o HTTP

// Verifica se o ambiente � de desenvolvimento
if (app.Environment.IsDevelopment())
{
    // Habilita o Swagger para documenta��o da API
    app.UseSwagger();

    // Habilita o Swagger UI para interface interativa
    app.UseSwaggerUI();
}

// Redireciona as solicita��es HTTP para HTTPS (Seguran�a)
app.UseHttpsRedirection();

// Adicione a autoriza��o aqui, se necess�rio

// Mapeie os controladores (rotas da API)
app.MapControllers();

// Inicializa a aplica��o
app.Run();
