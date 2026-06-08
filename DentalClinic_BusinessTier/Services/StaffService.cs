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
        private IStaffRepository  _staffRepository;
        private IPersonService _personService;
        private IRoleService _roleService;
        public StaffService(IPersonService personService,IRoleService roleService,IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;            
            _personService = personService;
            _roleService = roleService;
        }

        public async Task<clsStaff> GetByIdAsync(int objId)
        {
            clsStaff staff = await _staffRepository.GetStaffByIdAsync(objId);
            if (staff == null) return null;

            staff.Person = await _personService.GetByIdAsync(staff.Person_ID);
            staff.Role = await _roleService.GetByIdAsync(staff.Role_ID);

            return staff;
        }

        public async Task<clsStaff> LoginAsync(string username,string password)
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

            if (!await clsAuth.VerifyPassword(password,staffDataFromDB.HashedPassword))
            {
                throw new InvalidCredentialException("Username or Password Wrong");
            }

            staffDataFromDB.Role = await _roleService.GetByIdAsync(staffDataFromDB.Role_ID);
            if (staffDataFromDB.Role == null)
            {
                throw new Exception("Can not get role data");
            }

            staffDataFromDB.Person = await _personService.GetByIdAsync(staffDataFromDB.Person_ID);

            if (staffDataFromDB.Person == null)
            {
                throw new Exception("Can not get Person data");
            }

            return staffDataFromDB;
        }

        public async Task<int> InsertAsync(clsStaff obj)
        {            
            return await _staffRepository.AddStaffAsync(obj);
        }

        public async Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(clsStaff obj, int updatedByID = -1)
        {
            throw new NotImplementedException();
        }
    }
}
