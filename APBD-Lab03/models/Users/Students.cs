namespace APBD_Lab03.models.Users;

public class Student(string Name, string Email, string phoneNumber) : User(Name, Email, phoneNumber,2)
{
    public override string UserType => "Student";
    public override int MaxActiveRentals => 2;
}