namespace APBD_Lab03;

public class Projektor : Sprzet
{
    string model{get;set;}
    
    
    public Projektor(string nazwa, bool dostepnosc, float wartosc, float cenaZaDzien) : base(nazwa, dostepnosc, wartosc, cenaZaDzien)
    {
        
    }
}