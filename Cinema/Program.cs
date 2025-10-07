using CinemaAppDb.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connStr = "Data Source=Kelwoi\\SQLEXPRESS;Initial Catalog=CinemaWebDb;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True";

builder.Services.AddDbContext<CinemaDbContext>(options => 
 options.UseSqlServer(connStr));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
