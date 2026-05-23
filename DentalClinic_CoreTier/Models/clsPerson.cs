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
        public string SecondName { get; set; }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }           // 'M' or 'F'
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy_ID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy_ID { get; set; }

        // Navigation
        public clsStaff UpdatedBy { get; set; }
        public clsStaff DeletedBy { get; set; }
        public ICollection<clsPhoneNumber> PhoneNumbers { get; set; }
        public clsStaff Staff { get; set; }
        public clsPatient Patient { get; set; }
    }
}
