using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Models
{
    public class clsProblem
    {
        public int ProblemID { get; set; }
        public int MedicalFile_ID { get; set; }
        public string Diagnosis { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy_ID { get; set; }
        public string Status { get; set; } = "New";  // New | InProgress | Done | Closed
        public decimal TotalCost { get; set; }                // Doctor's set price

        // Navigation
        public clsMedicalFile MedicalFile { get; set; }
        public clsStaff UpdatedBy { get; set; }
    }
}
