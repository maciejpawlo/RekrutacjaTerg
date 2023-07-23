using RekrutacjaTerg.Infrastructure;
using RekrutacjaTerg.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//NOTE: allow all origins only for dev reasons
//in prod should specify concrete cors
var myCorsName = "mycors";
builder.Services.AddCors(p => p.AddPolicy("mycors", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myCorsName);

app.UseAuthorization();

app.MapControllers();

app.Run();
