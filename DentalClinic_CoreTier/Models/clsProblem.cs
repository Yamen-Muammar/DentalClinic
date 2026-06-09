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
        public myEnums.enProblemStatus Status { get; set; } = myEnums.enProblemStatus.New;
        public decimal? TotalCost { get; set; } // Doctor's set price
        public decimal? ActualPaid { get; set; }
        

    }
}
