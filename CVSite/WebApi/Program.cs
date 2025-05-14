using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.DependencyInjection;
using Service.Classes;
using WebApi.CachedService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//הזרקה למתודה הרחבה
builder.Services.AddGitHubIntegration(option=>builder.Configuration.GetSection(nameof(GitHubIntegrationOptions)).Bind(option));
//שליפת התוקן
builder.Services.Configure<GitHubIntegrationOptions>(builder.Configuration.GetSection("GitHubIntegrationOptions"));

//הוספת שירות הזיכרון מטמון
builder.Services.AddMemoryCache();

//builder.Services.Decorate<IGitHubService, CachedGitHubService>();//CachedGitHubService כולם יקבלו 

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
