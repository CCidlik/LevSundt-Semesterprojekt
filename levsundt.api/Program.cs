using LevSundt.Bmi.Application.Commands;
using LevSundt.Bmi.Application.Commands.Implementation;
using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Queries.Implementation;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model.DomainServices;
using LevSundt.Bmi.Infrastructor.DomainServices;
using LevSundt.Bmi.Infrastructor.Repositories;
using LevSundt.SqlServerContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Clean Architecture
builder.Services.AddScoped<ICreateBmiCommand, CreateBmiCommand>();
builder.Services.AddScoped<IEditBmiCommand, EditBmiCommand>();
builder.Services.AddScoped<IBmiRepository, BmiRepository>();
builder.Services.AddScoped<IBmiGetAllQuery, BmiGetAllQuery>();
builder.Services.AddScoped<IBmiGetQuery, BmiGetQuery>();
builder.Services.AddScoped<IBmiDomainService, BmiDomainService>();

// Database
// �bn Package Manager Console og k�r de her linjer hver for sig
// Add-Migration InitialMigration -Context LevSundtContext -Project LevSundt.SqlServerContext.Migrations
// Update-Database -Context LevSundtContext
builder.Services.AddDbContext<LevSundtContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("LevSundtDbConnection"),
            x => x.MigrationsAssembly("LevSundt.SqlServerContext.Migrations")));

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
