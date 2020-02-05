using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yearthreeproject.Models
{
    public class Consultation
    {
        public string PatientID { get; set; }
        public Patients Patients { get; set; }

        public string ConsultationID { get; set; }
        public Doctors Doctors { get; set; }
    }
}
