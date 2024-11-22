using Microsoft.EntityFrameworkCore;
using ProjetcManager.API;
using ProjetcManager.API.Data;
using ProjetcManager.API.Repositories;
using ProjetcManager.API.Repositories.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configuring DbContext
string StringConnection = builder.Configuration.GetConnectionString("SQLite")
    ?? throw new ArgumentException("Invalid String Connection!");

builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlite(StringConnection));

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
