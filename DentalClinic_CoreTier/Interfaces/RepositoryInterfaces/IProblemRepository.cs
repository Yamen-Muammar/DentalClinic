using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces
{
    public interface IProblemRepository
    {
        Task<int> AddProblemAsync(clsProblem problem);
        Task<clsProblem> GetProblemByIdAsync(int problemId);
        Task<IEnumerable<clsProblem>> GetProblemsByMedicalFileIdAsync(int medicalFileId);
        Task<bool> UpdateProblemAsync(clsProblem problem);

        // Specific method for quickly changing status without loading the whole object
        Task<bool> UpdateProblemStatusAsync(int problemId, myEnums.enProblemStatus status, int updatedById);
    }
}
