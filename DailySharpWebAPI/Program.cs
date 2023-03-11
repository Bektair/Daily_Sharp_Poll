using Microsoft.EntityFrameworkCore;
using DotEnv.Core;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

new EnvLoader().Load();
string connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION");
Console.WriteLine(connectionString);
Debug.WriteLine("----------------------------------------");
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<DailyContext>(opt => opt.UseSqlServer(connectionString));


builder.Services.AddScoped<IContributorRepository, ContributorRepository>();
builder.Services.AddScoped<IPollRepository, PollRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IPollPostRepository, PollPostRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
