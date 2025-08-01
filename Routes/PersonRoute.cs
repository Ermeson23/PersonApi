using Microsoft.EntityFrameworkCore;
using PersonApi.Data;
using PersonApi.Models;

namespace PersonApi.Routes;

public static class PersonRoute
{
    public static void PersonRoutes(this WebApplication app)
    {
        var baseRoute = app.MapGroup("person");

        baseRoute.MapPost("", async (PersonRequest req, PersonContext context) =>
        {
            var person = new PersonModel(req.Name);
            await context.AddAsync(person);
            await context.SaveChangesAsync();
        });

        baseRoute.MapGet("", async (PersonContext context) =>
        {
            var people = await context.People.ToListAsync();

            if (people == null || people.Count == 0)
                return Results.NotFound("Nenhuma pessoa encontrada.");

            return Results.Ok(people);
        });

        baseRoute.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
                return Results.NotFound();

            person.SetName(req.Name);
            await context.SaveChangesAsync();
            
            return Results.Ok(person);
        });
    }
}