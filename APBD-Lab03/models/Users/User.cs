
namespace APBD_Lab03.models.Users;

public abstract class User(string Name,string Lastname,string phoneNumber,int rentalLimit)
{
 
    private Guid Id { get; set; }=  Guid.NewGuid();
    private string Name { get; set; }
    private string LastName { get; set; }
    private string phoneNumber { get; set; }
    private int rentalLimit { get; set; }
    
    public abstract string UserType { get; }
    public abstract int MaxActiveRentals { get; }
    
    public override string ToString()
    {
        return $"[{UserType}] {Name} {LastName} (Limit wypożyczeń: {MaxActiveRentals})";
    }
}