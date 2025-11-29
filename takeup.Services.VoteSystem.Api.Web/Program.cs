using System.Text.Json;
using takeup.Configuration.Svc.DBContexts;
using takeup.Configuration.Svc.Services;
using takeup.Configuration.Svc.Services.Projects;

DotNetEnv.Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Config_Cors();
builder.Config_VoteSystem_DBContext();
builder.Config_VoteSystem_Inject();
builder.Config_MediatR();
builder.Config_Serilog();

// Config log
builder.Host.Config_Serilog_Host();

// Config Controller
builder.Services.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
				});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi("v1");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowedOrigins");

app.MapControllers();

await app.RunAsync();
