using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public StaffRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddStaffAsync(clsStaff staff)
        {
            try
            {
                int returnedStaffID = -1;
                const string query = @"
                    INSERT INTO Staff
                        (Person_ID, Role_ID, UserName, HashedPassword, HireDate, IsActive, CreatedAt)
                    VALUES
                        (@Person_ID, @Role_ID, @UserName, @HashedPassword, @HireDate, @IsActive, @CreatedAt);
                    SELECT SCOPE_IDENTITY();";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Person_ID",      staff.Person_ID);
                    cmd.Parameters.AddWithValue("@Role_ID",        staff.Role_ID);
                    cmd.Parameters.AddWithValue("@UserName",       staff.UserName);
                    cmd.Parameters.AddWithValue("@HashedPassword", staff.HashedPassword);
                    cmd.Parameters.AddWithValue("@HireDate",       (object)staff.HireDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive",       staff.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedAt",      staff.CreatedAt);

                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        returnedStaffID = insertedID;
                }
                return returnedStaffID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsStaff> GetStaffByIdAsync(int staffId)
        {
            try
            {
                const string query = @"
                    SELECT StaffID, Person_ID, Role_ID, UserName, HashedPassword, HireDate, IsActive,
                           CreatedAt, UpdatedAt, UpdatedBy_ID, IsDeleted, DeletedAt, DeletedBy_ID
                    FROM Staff
                    WHERE StaffID = @StaffID AND IsDeleted = 0";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffID", staffId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapStaff(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<clsStaff>> GetAllActiveStaffAsync()
        {
            try
            {
                const string query = @"
                    SELECT StaffID, Person_ID, Role_ID, UserName, HashedPassword, HireDate, IsActive,
                           CreatedAt, UpdatedAt, UpdatedBy_ID, IsDeleted, DeletedAt, DeletedBy_ID
                    FROM Staff
                    WHERE IsActive = 1 AND IsDeleted = 0";

                var list = new List<clsStaff>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapStaff(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateStaffAsync(clsStaff staff)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE Staff
                    SET Person_ID      = @Person_ID,
                        Role_ID        = @Role_ID,
                        UserName       = @UserName,
                        HashedPassword = @HashedPassword,
                        IsActive       = @IsActive,
                        UpdatedAt      = @UpdatedAt,
                        UpdatedBy_ID   = @UpdatedBy_ID
                    WHERE StaffID = @StaffID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffID",        staff.StaffID);
                    cmd.Parameters.AddWithValue("@Person_ID",      staff.Person_ID);
                    cmd.Parameters.AddWithValue("@Role_ID",        staff.Role_ID);
                    cmd.Parameters.AddWithValue("@UserName",       staff.UserName);
                    cmd.Parameters.AddWithValue("@HashedPassword", staff.HashedPassword);
                    cmd.Parameters.AddWithValue("@IsActive",       staff.IsActive);
                    cmd.Parameters.AddWithValue("@UpdatedAt",      (object)staff.UpdatedAt    ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy_ID",   (object)staff.UpdatedBy_ID ?? DBNull.Value);

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

        public async Task<clsStaff> GetStaffByUsernameAsync(string username)
        {
            try
            {
                const string query = @"
                    SELECT StaffID, Person_ID, Role_ID, UserName, HashedPassword, HireDate, IsActive,
                           CreatedAt, UpdatedAt, UpdatedBy_ID, IsDeleted, DeletedAt, DeletedBy_ID
                    FROM Staff
                    WHERE UserName = @UserName AND IsDeleted = 0";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapStaff(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ChangeActiveStatusAsync(int staffId, bool isActive, int updatedById)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE Staff
                    SET IsActive     = @IsActive,
                        UpdatedAt    = SYSDATETIME(),
                        UpdatedBy_ID = @UpdatedBy_ID
                    WHERE StaffID = @StaffID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffID",      staffId);
                    cmd.Parameters.AddWithValue("@IsActive",     isActive);
                    cmd.Parameters.AddWithValue("@UpdatedBy_ID", updatedById);

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

        private static clsStaff MapStaff(SqlDataReader reader)
        {
            int hireDateOrd  = reader.GetOrdinal("HireDate");
            int updatedAtOrd = reader.GetOrdinal("UpdatedAt");
            int updatedByOrd = reader.GetOrdinal("UpdatedBy_ID");
            int deletedAtOrd = reader.GetOrdinal("DeletedAt");
            int deletedByOrd = reader.GetOrdinal("DeletedBy_ID");

            return new clsStaff
            {
                StaffID        = reader.GetInt32(reader.GetOrdinal("StaffID")),
                Person_ID      = reader.GetInt32(reader.GetOrdinal("Person_ID")),
                Role_ID        = reader.GetInt32(reader.GetOrdinal("Role_ID")),
                UserName       = reader.GetString(reader.GetOrdinal("UserName")),
                HashedPassword = reader.GetString(reader.GetOrdinal("HashedPassword")),
                HireDate       = reader.IsDBNull(hireDateOrd) ? (DateTime?)null : reader.GetDateTime(hireDateOrd),
                IsActive       = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                CreatedAt      = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                IsDeleted      = reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                UpdatedAt      = reader.IsDBNull(updatedAtOrd) ? (DateTime?)null : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID   = reader.IsDBNull(updatedByOrd) ? (int?)null      : reader.GetInt32(updatedByOrd),
                DeletedAt      = reader.IsDBNull(deletedAtOrd) ? (DateTime?)null : reader.GetDateTime(deletedAtOrd),
                DeletedBy_ID   = reader.IsDBNull(deletedByOrd) ? (int?)null      : reader.GetInt32(deletedByOrd),
            };
        }
    }
}
