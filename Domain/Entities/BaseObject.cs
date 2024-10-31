namespace Domain.Entities;

public class BaseObject
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }

    
    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }
}