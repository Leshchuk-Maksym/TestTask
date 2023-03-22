using Microsoft.EntityFrameworkCore;
using TestTaskBLL.Interfaces;
using TestTaskBLL.Services;
using TestTaskDAL.Context;
using TestTaskDAL.Interfaces;
using TestTaskDAL.Respositories;

var builder = WebApplication.CreateBuilder(args);


string connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<TestTaskContext>(options => options
    .UseSqlServer(connectionString, b => b.MigrationsAssembly("TestTaskDAL"))
    .EnableSensitiveDataLogging(), ServiceLifetime.Transient);

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

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
