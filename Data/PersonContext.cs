using Microsoft.EntityFrameworkCore;
using PersonApi.Models;

namespace PersonApi.Data;

public class PersonContext : DbContext
{
    public DbSet<PersonModel> People { get; private set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=person.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}