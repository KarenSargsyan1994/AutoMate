using Automate.Domain.Entities.Base;

namespace Automate.Domain.Entities
{
    public sealed class Car : AggregateRoot
    {
        public Car(int id) : base(id)
        {            
        }
        
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public string OriginCountry { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ProductionYear { get; set; }
        public int CurrentMileage { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Maintenance> Maintenances { get; set; }
        public bool Inactive { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
