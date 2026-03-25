namespace APBD_Lab03.models;

public abstract class Hardware(string name)
{
    private Guid Id { get; set; } = Guid.NewGuid();
    private string Name { get; set; } = name;
    private bool IsAvailable { get; set; } = true;


    public override string ToString()
    {
        string status = IsAvailable ? "Dostępny" : "Niedostępny";
        return $"[{Id.ToString().Substring(0, 8)}] {Name} - Status: {status}";
    }
}