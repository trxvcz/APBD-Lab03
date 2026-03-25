
namespace APBD_Lab03.models.Users;

public abstract class User
{
 
    public Guid Id { get; set; }=  Guid.NewGuid();
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    
    public abstract string UserType { get; }
    public abstract int MaxActiveRentals { get; }

    protected User(string name, string lastname, string phoneNumber)
    {
        Name = name;
        LastName = lastname;
        PhoneNumber = phoneNumber;
    }
    
    public override string ToString()
    {
        return $"[{UserType}] {Name} {LastName} (Limit wypożyczeń: {MaxActiveRentals})";
    }
}