using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.DataTransferObjects.Technician
{
    public class TechnicianDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        public string Certification { get; set; }
        public bool Inactive { get; set; }
    }
}
