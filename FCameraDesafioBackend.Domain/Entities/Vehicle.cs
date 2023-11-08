namespace FCameraDesafioBackend.Domain.Entities;

public class Vehicle : BaseEntity
{
    public Vehicle(string brand, string model, string color, string plate, string type)
    {
        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Type = type;
    }

    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Color { get; private set; }
    public string Plate { get; private set; }
    public string Type { get; private set; }

    public void Update(string brand, string model, string color, string plate, string type)
    {
        base.Update();
        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Type = type;
    } 
}