namespace APBD_Lab03.models.Users;

public class Employee(string Name,string LastName,string phoneNumber):User( Name,LastName, phoneNumber)
{
    public override string UserType => "Pracownik";
    public override int MaxActiveRentals => 5;
}