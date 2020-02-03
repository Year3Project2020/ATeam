using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ATeam.Models
{
    public class PatientInput
    {
        public string ID { get; set; }
        public string IC { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public List<DoctorConsultation> DoctorConsultations { get; set; }
    }
}
