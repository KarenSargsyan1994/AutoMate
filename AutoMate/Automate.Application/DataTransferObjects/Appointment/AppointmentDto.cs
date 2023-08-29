
namespace Automate.Application.DataTransferObjects.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool Inactive { get; set; }
        public int CarId { get; set; }
        public int TechnicianId { get; set; }
        public int MaintenanceId { get; set; }
    }
}
