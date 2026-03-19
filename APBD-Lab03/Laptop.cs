namespace APBD_Lab03;

public class Laptop : Sprzet
{
    string type{get;set;}

    public Laptop(string nazwa, string type, bool dostepnosc, float wartosc) : base(nazwa: nazwa, wartosc: wartosc,
        dostepnosc: dostepnosc)
    {
        this.type = type;
    }
    
}