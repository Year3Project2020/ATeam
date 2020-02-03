using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATeam.Models
{
    public class DoctorConsultation
    {
        public string ID { get; set; }
        public PatientInput PatientInput { get; set; }

        public string PatientID { get; set; }
        public Consultation Consultation { get; set; }
    }
}
