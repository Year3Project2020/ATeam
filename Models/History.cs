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
        [Required]
        public string Patient { get; set; }
        public DateTime DateOfVisit { get; set; }
        [Required]
        public string Illness { get; set; }
        public string MedicationGiven { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }

    }
}
