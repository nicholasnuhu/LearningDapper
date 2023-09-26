using LearningDapper.Core.Interfaces;
using LearningDapper.Core.Services;
using LearningDapper.Infrastructure.Commons;
using LearningDapper.Infrastructure.Interfaces;
using LearningDapper.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISqlClientFactory, SqlClientFactory>();
builder.Services.AddScoped<ISqlConnectionsFactory, SqlConnectionsFactory>();
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