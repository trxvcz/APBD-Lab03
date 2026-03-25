namespace APBD_Lab03.models.Users;

public class Employee(string Name,string Email,string phoneNumber):User( Name, Email, phoneNumber,5)
{
    public override string UserType => "Pracownik";
    public override int MaxActiveRentals => 5;
}