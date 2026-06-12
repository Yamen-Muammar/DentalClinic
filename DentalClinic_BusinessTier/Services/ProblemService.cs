using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_BusinessTier.Services
{
    public class ProblemService : IProblemService
    {
        private IProblemRepository _problemRepository;
        public ProblemService(IProblemRepository problemRepository)
        {
            _problemRepository = problemRepository;
        }

        public Task<clsProblem> GetByIdAsync(int objId)
        {
            return _problemRepository.GetProblemByIdAsync(objId);
        }

        public Task<int?> InsertAsync(clsProblem obj)
        {
            _validateProblemObj(obj);
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsProblem obj,  int? updatedByID =null)
        {
            _validateProblemObj(obj);
            throw new NotImplementedException();
        }

        private bool _validateProblemObj(clsProblem problem)
        {
            if (problem == null)
                throw new ArgumentNullException("problem");

            if (problem.MedicalFile_ID <= 0)
                throw new ArgumentException("MedicalFile_ID must be a valid ID > 0");

            if (problem.TotalCost != null && problem.TotalCost < 0)
                throw new ArgumentException("TotalCost cannot be negative");

            if (problem.ActualPaid != null && problem.ActualPaid < 0)
                throw new ArgumentException("ActualPaid cannot be negative");

            if (problem.TotalCost != null && problem.ActualPaid != null && problem.ActualPaid > problem.TotalCost)
                throw new ArgumentException("ActualPaid cannot exceed TotalCost");

            return true;
        }
    }
}
