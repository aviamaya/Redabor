using Microsoft.EntityFrameworkCore;
using Redarbor.Core.Interfaces;
using Redarbor.Infraestructure.Data;
using Redarbor.Infraestructure.Implementation;
using System;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RedarborContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("RedarborDB")).EnableSensitiveDataLogging());
//builder.Services.AddDbContext<RedarborContext>(options => options.UseInMemoryDatabase("RedarborDB"));
builder.Services.AddScoped<IRedarbor, RedarborImpl>();

builder.Services.AddControllers(); 
builder.Services.AddCors(
    op => op.AddDefaultPolicy(pol =>
        pol.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Authorization"))
    );


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("corsapp");

app.MapControllers();

app.Run();
