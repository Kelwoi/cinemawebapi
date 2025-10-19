using BusinessLogic.Configure;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Cinema;
using CinemaAppDb.Data;
using CinemaAppDb.Data.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connStr = "Data Source=Kelwoi\\SQLEXPRESS;Initial Catalog=CinemaWebDb;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True";

builder.Services.AddDbContext<CinemaDbContext>(options => 
 options.UseSqlServer(connStr));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(cfg => { }, typeof(MapperProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
})
.AddEntityFrameworkStores<CinemaDbContext>()
.AddDefaultTokenProviders();
builder.Services.AddScoped<HallServices>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ISessionService, SessionServices>();
builder.Services.AddScoped<IFilmsService, FilmServices>();


var app = builder.Build();
app.UseGlobalExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
async Task SeedRolesAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

await SeedRolesAsync(app);
app.Run();

