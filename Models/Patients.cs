using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yearthreeproject.Models
{
    public class Patients
    {
        public string ID { get; set; }
        public string NRIC { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string History { get; set; }

        public List<Consultation> Consultations { get; set; }
    }
}
