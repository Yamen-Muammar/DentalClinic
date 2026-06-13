using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier.Interfaces.ServiceInterfaces
{
    public interface IProblemService : IGRUDService<clsProblem>
    {
        Task<bool> UpdateProblemStatusAsync(int problemId, myEnums.enProblemStatus status, int updatedById);
    }
}
