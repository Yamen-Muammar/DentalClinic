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
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(clsProblem obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(clsProblem obj, int updatedByID = -1)
        {
            throw new NotImplementedException();
        }
    }
}
