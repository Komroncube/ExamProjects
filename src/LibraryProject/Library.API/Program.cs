using JwtTokenProvider;
using Library.Application;
using Library.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSingleton<JwtTokenHandler>();
builder.Services.AddCustomJwtLayer();
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddInfrastructureLayer();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
