using Crip_117.Interfaces;
using Crip_117.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner de injeção de dependência.
builder.Services.AddControllers();

// Configure o Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Serviço de criptografia
builder.Services.AddTransient<ICryptographyService, CryptographyService>();

var app = builder.Build();

// Configure o pipeline de solicitação HTTP

// Verifica se o ambiente é de desenvolvimento
if (app.Environment.IsDevelopment())
{
    // Habilita o Swagger para documentação da API
    app.UseSwagger();

    // Habilita o Swagger UI para interface interativa
    app.UseSwaggerUI();
}

// Redireciona as solicitações HTTP para HTTPS (Segurança)
app.UseHttpsRedirection();

// Adicione a autorização aqui, se necessário

// Mapeie os controladores (rotas da API)
app.MapControllers();

// Inicializa a aplicação
app.Run();
