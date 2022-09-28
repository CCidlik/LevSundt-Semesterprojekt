using LevSundt.Bmi.Application.Commands;
using LevSundt.Bmi.Application.Commands.Implementation;
using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Queries.Implementation;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Infrastructor.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Clean Architecture
builder.Services.AddScoped<ICreateBmiCommand, CreateBmiCommand>();
builder.Services.AddScoped<IBmiRepository, BmiRepository>();
builder.Services.AddScoped<IBmiGetAllQuery, BmiGetAllQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
