using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_CoreTier
{
    public class clsAuth
    {
        public static Dictionary<string, long> DataBaseRoles = new Dictionary<string, long>();
        /// <summary>
        /// Check if the Login User is Authnticated By User Role.
        /// </summary>
        /// <param name="UserRole"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static bool IsAuth(long rolePermissionCode, myEnums.enPermission operation)
        {
            return _checkPermission(rolePermissionCode, (long)operation);
        }
        /// <summary>
        /// Check if the Login User is Authnticated By Manual Role Entering.
        /// </summary>
        /// <param name="role"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static bool IsAuth(myEnums.enRoles role, myEnums.enPermission operation)
        {
            if (DataBaseRoles.Count <= 0)
            {
                return false;
            }
            decimal roleCodeFromDataBase = DataBaseRoles[role.ToString()];
            return _checkPermission(roleCodeFromDataBase, (long)operation);
        }

        private static bool _checkPermission(decimal userRoleCode, decimal OperationCode)
        {            
            if ((Convert.ToInt64(OperationCode) & Convert.ToInt64(userRoleCode)) == Convert.ToInt64(OperationCode))
            {
                return true;
            }
            return false;
        }
    }
}
