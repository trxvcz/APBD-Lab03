using APBD_Lab03.models;

namespace APBD_Lab03;

public class Projector(string nazwa, string resolution, string inputType) : Hardware(nazwa)
{
    private string Resolution{get;set;} = resolution;
    private string InputType{get;set;} = inputType;

    public override string ToString()
    {
        return base.ToString() + $" (Projektor: {Resolution} px, InputType: {InputType})";
    }
}