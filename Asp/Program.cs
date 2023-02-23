using Asp.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeatherService, WeatherService>();
var app = builder.Build();
builder.Services.AddCors(option => option.AddPolicy("Ahuvi", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Ahuvi");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
