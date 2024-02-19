using DataAccess;
using LiveDemo.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PeopleDb");

builder.Services.AddDbContext<PeopleContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    }
);

builder.Services.AddSingleton<AnimalService>();

var app = builder.Build();

app.MapAnimalEndpoints();

app.MapGet("api/people", (PeopleContext context) =>
{
    return context.People;
});

app.MapPost("api/people", (PeopleContext context, Person person) =>
{
    context.Add(person);
    context.SaveChanges();
});

app.Run();
