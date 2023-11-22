namespace FCameraDesafioBackend.Domain.Entities;

public class EntryRecord : BaseEntity
{
    public EntryRecord(DateTime entry, DateTime exit, Guid userId, Guid vehicleId, Guid establishmentId)
    {
        Entry = entry;
        Exit = exit;
        UserId = userId;
        VehicleId = vehicleId;
        EstablishmentId = establishmentId;
    }

    public Guid EstablishmentId { get; private set; }
    public Guid VehicleId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime Entry { get; private set; }
    public DateTime Exit { get; private set; }
    public User? User { get; private set; }
    public Vehicle? Vehicle { get; private set; }
    public Establishment? Establishment { get; private set; }

    public void Update(DateTime entry, DateTime exit)
    {
        base.Update();
        Entry = entry;
        Exit = exit;
    }
}