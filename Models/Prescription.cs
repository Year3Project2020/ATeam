using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yearthreeproject.Models
{
    public class Prescription
    {
        public int ID { get; set; }
        public string Patient { get; set; }
        public string TypeOfMedication { get; set; }

        public string Price { get; set; }
        public string Status { get; set; }

    }
}
