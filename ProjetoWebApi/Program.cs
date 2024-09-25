using Microsoft.EntityFrameworkCore;
using ProjetoWebApi.ORM;
using ProjetoWebApi.Repositorio;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Adicione o contexto do banco de dados
builder.Services.AddDbContext<BdEmpresaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicione o repositório FuncionarioR
builder.Services.AddScoped<FuncionarioRepo>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
