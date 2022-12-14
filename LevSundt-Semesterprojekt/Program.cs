using LevSundt.WebApp.UserContext;
using LevSundt_Semesterprojekt.Infrastructure.Contact;
using LevSundt_Semesterprojekt.Infrastructure.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using LevSundt_Semesterprojekt.Areas.Identity.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add-Migration InitialMigration -Context ApplicationDbContext -Project LevSundt.WebApp.UserContext.Migrations
// Update-Database -Context ApplicationDbContext
var connectionString = builder.Configuration.GetConnectionString("WebAppUserDbConnection");



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString,

        x => x.MigrationsAssembly("LevSundt.WebApp.UserContext.Migrations")));
  

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Database
// �bn Package Manager Console og k�r de her linjer hver for sig
// Add-Migration InitialMigration -Context ApplicationDbContext 
// Update-Database -Context ApplicationDbContext
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CoachPolicy", policyBuilder => policyBuilder.RequireClaim("Coach"));
});
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Bmi");
    options.Conventions.AuthorizeFolder("/Coach", "CoachPolicy");
});

// IHttpClientFactory
//ops find ud af hvordan man fixer at api ikke peger på WEbapp altså semesterproject for os og istedet peger på det rigtige
builder.Services.AddHttpClient<ILevSundtService, LevSundtService>(
    client => client.BaseAddress = new Uri(builder.Configuration["LevSundtBaseUrl"]));

////Clean Architecture
//builder.Services.AddScoped<ICreateBmiCommand, CreateBmiCommand>();
//builder.Services.AddScoped<IEditBmiCommand, EditBmiCommand>();
//builder.Services.AddScoped<IBmiRepository, BmiRepository>();
//builder.Services.AddScoped<IBmiGetAllQuery, BmiGetAllQuery>();
//builder.Services.AddScoped<IBmiGetQuery, BmiGetQuery>();
//builder.Services.AddScoped<IBmiDomainService, BmiDomainService>();

//// Database
//// �bn Package Manager Console og k�r de her linjer hver for sig
//// Add-Migration InitialMigration -Context LevSundtContext -Project LevSundt.SqlServerContext.Migrations
//// Update-Database -Context LevSundtContext
//builder.Services.AddDbContext<LevSundtContext>(
//    options => 
//        options.UseSqlServer(builder.Configuration.GetConnectionString("LevSundtDbConnection"),
//            x => x.MigrationsAssembly("LevSundt.SqlServerContext.Migrations")));

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
app.UseAuthentication();;

app.UseAuthorization();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
