using APBD_Lab03.models;

namespace APBD_Lab03;

public class Camera(string name, string sensorType, string videoResolution) : Hardware(name)
{
    private string SensorType{get;set;} = sensorType;
    private string VideoResolution{get;set;} = videoResolution;

    public override string ToString()
    {
        return base.ToString() + $" (Camera: {SensorType}, VideoResolution: {VideoResolution})";
    }
}   