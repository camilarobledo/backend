using EmpresaAPI.Data;           
using Microsoft.EntityFrameworkCore;
using EmpresaAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmpresaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmpresaDb")));

builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

