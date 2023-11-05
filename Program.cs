using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using AssistantCoachAPI.Models;
using AssistantCoachAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Exercises") ?? "Data Source=Exercises.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<ExerciseDb>(connectionString);
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "AssistantCoach API",
         Description = "Sports exercises for athletes",
         Version = "v1" });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "AssistantCoach API V1");
});

ExerciseController.Map(app);

app.Run();