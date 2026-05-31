using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly string _connectionString;
        public ProblemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<int> AddProblemAsync(clsProblem problem)
        {
            throw new NotImplementedException();
        }

        public Task<clsProblem> GetProblemByIdAsync(int problemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<clsProblem>> GetProblemsByMedicalFileIdAsync(int medicalFileId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProblemAsync(clsProblem problem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProblemStatusAsync(int problemId, string status, int updatedById)
        {
            throw new NotImplementedException();
        }
    }
}
