using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yearthreeproject.Models
{
    public class Doctors
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime NextAppointment { get; set; }

        public List<Consultation> Consultations { get; set; }
    }
}
