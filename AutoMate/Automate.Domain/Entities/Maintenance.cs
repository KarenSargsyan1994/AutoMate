using Automate.Domain.Entities.Base;
using Automate.Domain.Enums;

namespace Automate.Domain.Entities
{
    public sealed class Maintenance : Entity
    {
        public Maintenance(int id) : base(id)
        {
        }

        public string Description { get; set; }
        public int IntervalInMiles { get; set; }
        public int CurrentMileage { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PreviewServiceDate { get; set; }
        public DateTime NextServiceDate { get; set; }
        public MaintenanceType Type { get; set; }
        public bool Inactive { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
