using Automate.Application.DataTransferObjects.Car;
using Automate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.DataTransferObjects.Maintenance
{
    public class MaintenanceDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int IntervalInMiles { get; set; }
        public int CurrentMileage { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PreviewServiceDate { get; set; }
        public DateTime NextServiceDate { get; set; }
        public MaintenanceType Type { get; set; }
        public bool Inactive { get; set; }
        public int CarId { get; set; }
    }
}
