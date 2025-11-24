using CinemaPipocando.Data;

using CinemaPipocando.Routes;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar o CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CinemaContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// 2. Ativar o CORS antes dos endpoints
app.UseCors("AllowAll");

app.FilmeRoutes();

app.UseHttpsRedirection();
app.Run();