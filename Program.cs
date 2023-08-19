using ApiExamen;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// MySQL Config
var connectionString = builder.Configuration.GetConnectionString("MySQLDatabase");
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

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

// CORS Config
app.UseCors(policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
