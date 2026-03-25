using APBD_Lab03.models;

namespace APBD_Lab03;

public class Laptop(string name, int ramSizeGb, string processorModel) : Hardware(name)
{
    private int RamSizeGb { get; set; } = ramSizeGb;
    private string ProcessorModel { get; set; } = processorModel;

    public override string ToString()
    {
        return base.ToString() + $" (Laptop: {RamSizeGb}GB RAM, CPU: {ProcessorModel})";
    }
}