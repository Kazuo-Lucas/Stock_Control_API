using ControleEstoqueApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Controllers.
builder.Services.AddControllers();

// Adiciona suporte a Swagger para documentação da API.
builder.Services.AddEndpointsApiExplorer(   );
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=estoque.db"));

var app = builder.Build();

// Configura o swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Roteamento para Controllers
app.UseAuthorization();
//Ativa os Controllers
app.MapControllers();

app.Run();
