namespace APBD_Lab03;

public abstract class Sprzet
{
    int IdSprzet {get;set;}
    string Nazwa {get;set;}
    bool Dostepnosc {get;set;}
    float Wartosc {get;set;}

    public Sprzet(string nazwa, bool dostepnosc, float wartosc)
    {
        this.Nazwa = nazwa;
        this.Dostepnosc = dostepnosc;
        this.Wartosc = wartosc;
    }
}