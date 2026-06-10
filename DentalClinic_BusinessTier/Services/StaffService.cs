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
        private IRoleService _roleService;
        private IPersonService _personService;

        public StaffService(IStaffRepository staffRepository,IRoleService roleService , IPersonService personService)
        {
            _staffRepository = staffRepository;
            _roleService = roleService;
            _personService  = personService;
        }

        public async Task<clsStaff> GetByIdAsync(int objId)
        {
            clsStaff Staff = await _staffRepository.GetStaffByIdAsync(objId);
            if (Staff == null)
            {
                return null;
            }

            Staff.RoleInfo = await _roleService.GetByIdAsync(Staff.Role_ID);

            Staff.PersonInfo = await _personService.GetByIdAsync(Staff.Person_ID);        
            
            return Staff;
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

            staffDataFromDB.RoleInfo = await _roleService.GetByIdAsync(staffDataFromDB.Role_ID);

            staffDataFromDB.PersonInfo = await _personService.GetByIdAsync(staffDataFromDB.Person_ID);

            return staffDataFromDB;
        }

        public async Task<int?> InsertAsync(clsStaff obj)
        {            
            return await _staffRepository.AddStaffAsync(obj);
        }

        public async Task<bool> SoftDeleteAsync(int objId, int deletedById)
        {
           return await _staffRepository.SoftDeleteStaff(objId, deletedById);
        }

        public async Task<bool> UpdateAsync(clsStaff obj, int? updatedByID = null)
        {
            if (!_validateStaff(obj))
            {
                throw new ArgumentException("Invalid staff data");
            }

            if (updatedByID == null)
            {
                throw new ArgumentNullException("Update ID Just be provided");
            }

            obj.UpdatedBy_ID = updatedByID;

            return await _staffRepository.UpdateStaffAsync(obj);
        }

        private bool _validateStaff(clsStaff staff)
        {
            if (staff == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(staff.UserName) || string.IsNullOrEmpty(staff.HashedPassword))
            {
                return false;
            }
            if (staff.Person_ID <= 0 || staff.Role_ID <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
