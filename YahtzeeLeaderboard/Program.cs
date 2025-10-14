using AutoMapper;
using Microsoft.EntityFrameworkCore;

using YahtzeeLeaderboard.Data;
using YahtzeeLeaderboard.Interfaces;
using YahtzeeLeaderboard.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IScorecardService, ScorecardService>();

// Add dbContext with SQLite
builder.Services.AddDbContext<YahtzeeLeaderboardContext>(options => 
    options.UseSqlite("Data Source=./yahtzeeScores.db"));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
    