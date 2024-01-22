using Keeper.Domen.Data;
using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using Keeper.Domen.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserRepository, UserLocalRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton<IStatementRepository, StatementLocalRepository>();
builder.Services.AddScoped<IStatementService, StatementService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("api/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapPost("/users", async (User user, IUserService userService) =>
{
    userService.AddUser(user);
    Console.WriteLine(userService.CountUsers());
    return Results.Created($"/todoitems/{user.Id}", user);
});

app.MapGet("/users", (IUserService userService) =>
{
   Console.WriteLine(userService.CountUsers());
   return userService.GetUsers() ;
});

app.MapGet("/statements", (IStatementService statementService) =>
{
    return statementService.GetStatements();
});


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
