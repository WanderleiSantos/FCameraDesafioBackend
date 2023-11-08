namespace FCameraDesafioBackend.Domain.Entities;

public class Establishment : BaseEntity
{
    public Establishment(string name, string cnpj, string address, string telephone, int numberParkingCars,
        int numberParkingMotorcycles)
    {
        Name = name;
        Cnpj = cnpj;
        Address = address;
        Telephone = telephone;
        NumberParkingCars = numberParkingCars;
        NumberParkingMotorcycles = numberParkingMotorcycles;
    }

    public string Name { get; private set; }
    public string Cnpj { get; private set; }
    public string Address { get; private set; }
    public string Telephone { get; private set; }
    public int NumberParkingCars { get; private set; }
    public int NumberParkingMotorcycles { get; private set; }

    public void Update(string name, string cnpj, string address, string telephone, int numberParkingCars,
        int numberParkingMotorcycles)
    {
        base.Update();
        Name = name;
        Cnpj = cnpj;
        Address = address;
        Telephone = telephone;
        NumberParkingCars = numberParkingCars;
        NumberParkingMotorcycles = numberParkingMotorcycles;
    }
}