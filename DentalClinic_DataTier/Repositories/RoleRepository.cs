using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public RoleRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddRoleAsync(clsRole role)
        {
            try
            {
                int returnedRoleID = -1;
                const string query = @"
                    INSERT INTO enRoles (RoleName, RolePermissionCode)
                    VALUES (@RoleName, @RolePermissionCode);
                    SELECT SCOPE_IDENTITY();";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleName",           role.RoleName);
                    cmd.Parameters.AddWithValue("@RolePermissionCode", role.RolePermissionCode);

                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        returnedRoleID = insertedID;
                }
                return returnedRoleID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsRole> GetRoleByIdAsync(int roleId)
        {
            try
            {
                const string query = @"
                    SELECT RoleID, RoleName, RolePermissionCode
                    FROM enRoles
                    WHERE RoleID = @RoleID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleID", roleId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapRole(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Dictionary<string, long>> GetAllRolesAsync()
        {
            try
            {
                const string query = @"
                    SELECT RoleID, RoleName, RolePermissionCode
                    FROM Roles";

                Dictionary<string, long> keyValues = new Dictionary<string, long>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                           clsRole role =  MapRole(reader);
                           keyValues[role.RoleName] = role.RolePermissionCode;
                        }                            
                    }
                }
                return keyValues;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateRoleAsync(clsRole role)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE enRoles
                    SET RoleName           = @RoleName,
                        RolePermissionCode = @RolePermissionCode
                    WHERE RoleID = @RoleID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleID",             role.RoleID);
                    cmd.Parameters.AddWithValue("@RoleName",           role.RoleName);
                    cmd.Parameters.AddWithValue("@RolePermissionCode", role.RolePermissionCode);

                    await conn.OpenAsync();
                    isUpdated = await cmd.ExecuteNonQueryAsync() > 0;
                }
                return isUpdated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateRolePermissionsAsync(int roleId, decimal permissionCode)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE enRoles
                    SET RolePermissionCode = @RolePermissionCode
                    WHERE RoleID = @RoleID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleID",             roleId);
                    cmd.Parameters.AddWithValue("@RolePermissionCode", (long)permissionCode);

                    await conn.OpenAsync();
                    isUpdated = await cmd.ExecuteNonQueryAsync() > 0;
                }
                return isUpdated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static clsRole MapRole(SqlDataReader reader)
        {
            return new clsRole
            {
                RoleID             = reader.GetInt32(reader.GetOrdinal("RoleID")),
                RoleName           = reader.GetString(reader.GetOrdinal("RoleName")),
                RolePermissionCode = Convert.ToInt64(reader["RolePermissionCode"]),
            };
        }
    }
}
