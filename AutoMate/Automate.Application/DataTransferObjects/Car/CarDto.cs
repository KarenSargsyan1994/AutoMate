using Automate.Application.DataTransferObjects.Appointment;
using Automate.Application.DataTransferObjects.Maintenance;
using Automate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.DataTransferObjects.Car
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public string OriginCountry { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ProductionYear { get; set; }
        public int CurrentMileage { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
        public List<MaintenanceDto> Maintenances { get; set; }
        public bool Inactive { get; set; }
        public int OwnerId { get; set; }
    }
}
