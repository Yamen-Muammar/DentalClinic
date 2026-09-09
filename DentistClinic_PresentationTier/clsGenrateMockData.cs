using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistClinic_PresentationTier
{
    static class clsGenrateMockData
    {
        public static List<clsAppointmentsDetails> _loadMockAppointments()
        {
            return new List<clsAppointmentsDetails>()
{
    new clsAppointmentsDetails
    {
        MedicalFileID = 101,
        PatientID = 1,
        PatientFullName = "أحمد مصطفى السيد",
        PatientPhone = "+20 100 123 4567",
        DoctorFullName = "د. سارة إبراهيم",
        Appointment = new clsAppointment
        {
            AppointmentID = 501,
            AppointmentDate = DateTime.Today,
            StartTime = new TimeSpan(9, 0, 0),
            EndTime = new TimeSpan(9, 45, 0),
            Status = DentalClinic_CoreTier.myEnums.enAppointmentStatus.Scheduled,
            Cause = "ألم حاد في الضرس السفلي الأيمن مع انتفاخ خفيف باللثة"
        }
    },
    new clsAppointmentsDetails
    {
        MedicalFileID = 102,
        PatientID = 2,
        PatientFullName = "مريم خالد رضوان",
        PatientPhone = "+20 111 234 5678",
        DoctorFullName = "د. سامي الجوهري",
        Appointment = new clsAppointment
        {
            AppointmentID = 502,
            AppointmentDate = DateTime.Today,
            StartTime = new TimeSpan(10, 15, 0),
            EndTime = new TimeSpan(11, 0, 0),
            Status = DentalClinic_CoreTier.myEnums.enAppointmentStatus.NoShow,
            Cause = "جلسة فحص دوري وتنظيف وتلميع الأسنان وإزالة الجير"
        }
    },
    new clsAppointmentsDetails
    {
        MedicalFileID = 103,
        PatientID = 3,
        PatientFullName = "يوسف عبد الرحمن حسن",
        PatientPhone = "+20 122 345 6789",
        DoctorFullName = "د. سامي الجوهري",
        Appointment = new clsAppointment
        {
            AppointmentID = 503,
            AppointmentDate = DateTime.Today,
            StartTime = new TimeSpan(11, 30, 0),
            EndTime = new TimeSpan(12, 15, 0),
            Status = DentalClinic_CoreTier.myEnums.enAppointmentStatus.Scheduled,
            Cause = "متابعة دورية وتعديل أسلاك تقويم الأسنان للفكين"
        }
    },
    new clsAppointmentsDetails
    {
        MedicalFileID = 104,
        PatientID = 4,
        PatientFullName = "عمر طارق النجار",
        PatientPhone = "+20 102 345 6789",
        DoctorFullName = "د. سارة إبراهيم",
        Appointment = new clsAppointment
        {
            AppointmentID = 504,
            AppointmentDate = DateTime.Today.AddDays(1),
            StartTime = new TimeSpan(13, 0, 0),
            EndTime = new TimeSpan(13, 30, 0),
            Status = DentalClinic_CoreTier.myEnums.enAppointmentStatus.Confirmed,
            Cause = "سقوط حشوة تجميلية سابقة مع حساسية شديدة للمشروبات الباردة"
        }
    },
    new clsAppointmentsDetails
    {
        MedicalFileID = 105,
        PatientID = 5,
        PatientFullName = "ليلى محمود المهدي",
        PatientPhone = null, // Null safety handling
        DoctorFullName = "د. محمد كمال عثمان",
        Appointment = new clsAppointment
        {
            AppointmentID = 505,
            AppointmentDate = DateTime.Today.AddDays(1),
            StartTime = new TimeSpan(14, 0, 0),
            EndTime = new TimeSpan(15, 0, 0),
            Status = DentalClinic_CoreTier.myEnums.enAppointmentStatus.Confirmed,
            Cause = "جلسة علاج جذور (سحب عصب) للضرس الأول العلوي"
        }
    }
};

        }

    }
}
