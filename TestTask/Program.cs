using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.Context;
using TestTask.DataAccess.Interfaces;
using TestTask.DataAccess.Repositories;
using TestTask.Domain.Interfaces;
using TestTask.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TestTaskContext>(options => options
    .UseSqlServer(connectionString, b => b.MigrationsAssembly("TestTask.DataAccess"))
    .EnableSensitiveDataLogging());


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAccountService, AccountService>();

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
