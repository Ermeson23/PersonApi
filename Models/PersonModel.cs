namespace PersonApi.Models;

public class PersonModel
{
    public PersonModel(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        Active = true;
    }

    public Guid Id { get; init; }
    public string Name { get; private set; }
    public Boolean Active { get; private set; }
    public void SetName(string name)
    {
        Name = name;
    }

    public void Deactivate()
    {
        Active = false;
    }

    public void Activate()
    {
        Active = true;
    }
    
}