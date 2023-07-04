

using Microsoft.EntityFrameworkCore;
using Securities.API.Models;
using Securities.API.Repositories;
using Securities.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//UserDataAccessLayer
builder.Services.AddScoped<UserDataAccessLayer>();

//Connection Configuration
builder.Services.AddTransient<IConnectionConfig, ConnectionConfig>();

//Adding DBCOntext
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));


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
