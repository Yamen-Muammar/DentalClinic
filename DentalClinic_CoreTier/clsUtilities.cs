using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic_CoreTier
{
    public  static class clsUtilities
    {
        public static string GetAppointmentStatusText(myEnums.enAppointmentStatus status)
        {
            switch (status)
            {
                case myEnums.enAppointmentStatus.Confirmed:
                    return "مؤكـد";
                case myEnums.enAppointmentStatus.Cancelled:
                    return "ملغى";
                case myEnums.enAppointmentStatus.NoShow:
                    return "غير حاضر";
                case myEnums.enAppointmentStatus.Scheduled:
                    return "محجوز";
                    case myEnums.enAppointmentStatus.Completed:
                    return "مكتمل";
                default:
                    return "؟؟؟";
            }
        }
        public static string GetPersonGenderText(myEnums.enGenderTypes gender)
        {
            switch (gender)
            {
                case myEnums.enGenderTypes.M:
                    return "ذَكـر";
                case myEnums.enGenderTypes.F:
                    return "أُنثـى";
                default:
                    return "؟؟؟";
            }
        }

    }
}
