using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ATeam.Models
{
    public class Consultation
    {
        public string ID { get; set; }
        public string IC { get; set; }
        public string Name { get; set; }

        [Display(Name = "Consultation Date")]
        [DataType(DataType.Date)]
        public DateTime ConsultationDate { get; set; }

        public List<DoctorConsultation> DoctorConsultations { get; set; }
    }
}
