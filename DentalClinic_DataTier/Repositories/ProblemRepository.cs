using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProblemRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<int> AddProblemAsync(clsProblem problem)
        {
            throw new System.NotImplementedException();
        }

        public Task<clsProblem> GetProblemByIdAsync(int problemId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<clsProblem>> GetProblemsByMedicalFileIdAsync(int medicalFileId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateProblemAsync(clsProblem problem)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateProblemStatusAsync(int problemId, string status, int updatedById)
        {
            throw new System.NotImplementedException();
        }
    }
}
