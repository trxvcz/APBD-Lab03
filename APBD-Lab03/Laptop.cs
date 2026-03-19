namespace APBD_Lab03;

public class Laptop : Sprzet
{
    string model{get;set;}
    string procesor{get;set;}
    int pamiecGB{get;set;}
    
    public Laptop(string nazwa, string model, bool dostepnosc, float wartosc, float CenaZaDzien) : base(nazwa: nazwa, wartosc: wartosc,
        dostepnosc: dostepnosc,cenaZaDzien: CenaZaDzien)
    {   
        this.model  = model;
        
        
        
    }
    
}