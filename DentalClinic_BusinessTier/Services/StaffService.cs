using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.ServiceInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_BusinessTier.Services
{
    public class StaffService : IStaffService
    {
        private IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public Task<clsStaff> GetByIdAsync(int objId)
        {
            return _staffRepository.GetStaffByIdAsync(objId);
        }

        public async Task<clsStaff> LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) throw new ArgumentNullException("username or password is null");

            clsStaff staffDataFromDB = await _staffRepository.GetStaffByUsernameAsync(username);

            if (staffDataFromDB == null)
            {
                throw new InvalidCredentialException("Username or Password Wrong");
            }

            if (!staffDataFromDB.IsActive)
            {
                throw new AuthenticationException("Staff is not active");
            }

            if (!await clsAuth.VerifyPassword(password, staffDataFromDB.HashedPassword))
            {
                throw new InvalidCredentialException("Username or Password Wrong");
            }

            return staffDataFromDB;
        }

        public async Task<int?> InsertAsync(clsStaff obj)
        {            
            return await _staffRepository.AddStaffAsync(obj);
        }

        public async Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(clsStaff obj, int? updatedByID =null)
        {
            throw new NotImplementedException();
        }
    }
}
