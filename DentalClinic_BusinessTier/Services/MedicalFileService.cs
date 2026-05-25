using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;

namespace DentalClinic_BusinessTier.Services
{
    public class MedicalFileService
    {
        private IMedicalFileRepository _medicalFileRepository;
        public MedicalFileService(IMedicalFileRepository medicalFileRepository)
        {
            _medicalFileRepository = medicalFileRepository;
        }
    }
}
