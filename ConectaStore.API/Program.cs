using ConectaStore.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string conexao = builder.Configuration.GetConnectionString("Conexao");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(conexao)
);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
   c.SwaggerDoc("v1", new OpenApiInfo
   {
       Title = "ConectaStore Api",
       Version = "v1",
       Description = "API de fornecimento de dados de produtos",
   }); 
});

var app = builder.Build();

// Garante que o banco exista ao executar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/.json", "ConectaStore.API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
