using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Models
{
    public class clsPerson
    {
        public int PersonID { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string SecondName { get; set; } = null; //nullable
        public string NationalNo { get; set; } = null; //nullable
        public DateTime? DateOfBirth { get; set; } = null;
        public myEnums.enGenderTypes Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public int? UpdatedBy_ID { get; set; } = null;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public int? DeletedBy_ID { get; set; } = null;

    }
}
