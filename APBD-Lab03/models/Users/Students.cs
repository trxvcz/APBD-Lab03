namespace APBD_Lab03.models.Users;

public class Student(string Name, string LastName, string phoneNumber) : User(Name, LastName, phoneNumber)
{
    public override string UserType => "Student";
    public override int MaxActiveRentals => 2;
}