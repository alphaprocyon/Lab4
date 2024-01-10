using Lab3.Commands;
using Lab3.Data;
using Lab3.Models;
using Lab3.Models.Commands;
using Lab4.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<TurtleContext>(
    options =>
        options.UseSqlite(TurtleContext.DefaultConnection())
);
builder.Services.AddScoped<ICommandService, CommandService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
