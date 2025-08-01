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
            if (string.IsNullOrWhiteSpace(req.Name))
                return Results.BadRequest("O campo nome não pode ser vazio ou nulo.");

            var person = new PersonModel(req.Name);

            await context.AddAsync(person);
            await context.SaveChangesAsync();

            return Results.Ok(person);
        });

        baseRoute.MapGet("", async (PersonContext context) =>
        {
            var people = await context.People.Where(p => p.Active).ToListAsync();

            if (people == null || people.Count == 0)
                return Results.NotFound("Nenhuma pessoa ativa encontrada.");

            return Results.Ok(people);
        });

        baseRoute.MapGet("/{id}", async (Guid id, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(p => p.Id == id && p.Active);

            if (person == null)
                return Results.NotFound("Pessoa não encontrada ou está inativa.");

            return Results.Ok(person);
        });

        baseRoute.MapPut("/{id}", async (Guid id, PersonRequest req, PersonContext context) =>
        {
            if (string.IsNullOrWhiteSpace(req.Name))
                return Results.BadRequest("O campo nome não pode ser vazio ou nulo.");

            var person = await context.People.FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
                return Results.NotFound();

            person.SetName(req.Name);
            await context.SaveChangesAsync();

            return Results.Ok(person);
        });

        baseRoute.MapDelete("/{id}", async (Guid id, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(p => p.Id == id && p.Active);

            if (person == null)
                return Results.NotFound("Pessoa não encontrada ou já desativada.");

            person.Deactivate();
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        baseRoute.MapPatch("/{id}/activate", async (Guid id, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
                return Results.NotFound("Pessoa não encontrada.");

            if (person.Active)
                return Results.BadRequest("Pessoa já está ativa.");

            person.Activate();
            await context.SaveChangesAsync();

            return Results.Ok("Pessoa reativada com sucesso.");
        });
    }
}