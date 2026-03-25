namespace APBD_Lab03.models;

public abstract class Hardware(string name)
{
    public Guid Id { get;private set; } = Guid.NewGuid();
    public string Name { get;private set; } = name;
    public bool IsAvailable { get; private set; } = true;
    
    public void MarkAsRented()
    {
        IsAvailable = false;
    }
    
    public void MarkAsReturned()
    {
        IsAvailable = true;
    }
    
    public void MarkAsUnavailable()
    {
        IsAvailable = false;
    }

    public void MarkAsAvailable()
    {
        IsAvailable = true;
    }
    
    public override string ToString()
    {
        string status = IsAvailable ? "Dostępny" : "Niedostępny";
        return $"[{Id.ToString().Substring(0, 8)}] {Name} - Status: {status}";
    }
}