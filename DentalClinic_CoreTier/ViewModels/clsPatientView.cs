using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic_CoreTier.ViewModels
{
    public class clsPatientView
    {
        public int    ID            { get; set; }
        public string FullName      { get; set; }
        public string Age           { get; set; }
        public string Gender        { get; set; }
        public string PhoneNumber   { get; set; }
        public string BloodTypeName { get; set; }
    }
}
