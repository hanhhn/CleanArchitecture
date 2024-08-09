using Application;
using Infrastructure;
using Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var version = typeof(Program).Assembly.GetName()?.Version?.ToString();
Console.WriteLine($"Applicaton with version {version} at {DateTime.Now}");
builder.Configuration.ConfigureAppConfiguration(builder.Environment);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddWebServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddHttpContextAccessor()
    .AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.EnsureCreated();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

