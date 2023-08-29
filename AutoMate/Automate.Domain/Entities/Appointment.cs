using Automate.Domain.Entities.Base;

namespace Automate.Domain.Entities
{
    public sealed class Appointment : Entity
    {
        public Appointment(int id) : base(id)
        {
        }
        
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool Inactive { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }

        public int MaintenanceId { get; set; }
        public Maintenance Maintenance { get; set; }
    }
}
