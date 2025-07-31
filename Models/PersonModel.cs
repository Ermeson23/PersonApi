namespace PersonApi.Models;

public class PersonModel
{
    public PersonModel(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; init; }
    public string Name { get; private set; }
}