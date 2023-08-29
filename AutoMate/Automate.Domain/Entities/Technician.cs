using Automate.Domain.Entities.Base;

namespace Automate.Domain.Entities
{
    public sealed class Technician : Entity
    {
        public Technician(int id) : base(id)
        {
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        public string Certification { get; set; }
        public bool Inactive { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
