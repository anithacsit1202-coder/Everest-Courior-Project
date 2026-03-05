
namespace CourierService.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; }
        public int Speed { get; }
        public int MaxLoad { get; }
        public double AvailableAt { get; set; }

        public Vehicle(int id, int speed, int maxLoad)
        {
            Id = id;
            Speed = speed;
            MaxLoad = maxLoad;
            AvailableAt = 0;
        }
    }
}
