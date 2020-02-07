using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yearthreeproject.Models
{
    public class History
    {
        public string ID { get; set; }
        public string Patient { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string Illness { get; set; }
        public string MedicationGiven { get; set; }

    }
}
