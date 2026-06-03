using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DoctorRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddDoctorAsync(clsDoctor doctor)
        {
            int returnedDoctorID = -1;
            const string query = @"
                INSERT INTO Doctors (Staff_ID, Specialization, LicenseNumber, CreatedAt)
                VALUES (@Staff_ID, @Specialization, @LicenseNumber, @CreatedAt);
                SELECT SCOPE_IDENTITY();";

            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Staff_ID",       doctor.Staff_ID);
                cmd.Parameters.AddWithValue("@Specialization", (object)doctor.Specialization ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseNumber",  (object)doctor.LicenseNumber  ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedAt",      doctor.CreatedAt);

                await conn.OpenAsync();
                var result = await cmd.ExecuteScalarAsync();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    returnedDoctorID = insertedID;
            }
            return returnedDoctorID;
        }

        public async Task<clsDoctor> GetDoctorByIdAsync(int doctorId)
        {
            const string query = @"
                SELECT DoctorID, Staff_ID, Specialization, LicenseNumber, CreatedAt, UpdatedAt, UpdatedBy_ID
                FROM Doctors
                WHERE DoctorID = @DoctorID";

            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                        return MapDoctor(reader);
                }
            }
            return null;
        }

        public async Task<clsDoctor> GetDoctorByStaffIdAsync(int staffId)
        {
            const string query = @"
                SELECT DoctorID, Staff_ID, Specialization, LicenseNumber, CreatedAt, UpdatedAt, UpdatedBy_ID
                FROM Doctors
                WHERE Staff_ID = @Staff_ID";

            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Staff_ID", staffId);
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                        return MapDoctor(reader);
                }
            }
            return null;
        }

        public async Task<IEnumerable<clsDoctor>> GetAllDoctorsAsync()
        {
            const string query = @"
                SELECT DoctorID, Staff_ID, Specialization, LicenseNumber, CreatedAt, UpdatedAt, UpdatedBy_ID
                FROM Doctors";

            var list = new List<clsDoctor>();
            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                        list.Add(MapDoctor(reader));
                }
            }
            return list;
        }

        public async Task<bool> UpdateDoctorAsync(clsDoctor doctor)
        {
            bool isUpdated = false;
            const string query = @"
                UPDATE Doctors
                SET Staff_ID       = @Staff_ID,
                    Specialization = @Specialization,
                    LicenseNumber  = @LicenseNumber,
                    UpdatedAt      = @UpdatedAt,
                    UpdatedBy_ID   = @UpdatedBy_ID
                WHERE DoctorID = @DoctorID";

            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@DoctorID",       doctor.DoctorID);
                cmd.Parameters.AddWithValue("@Staff_ID",       doctor.Staff_ID);
                cmd.Parameters.AddWithValue("@Specialization", (object)doctor.Specialization ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LicenseNumber",  (object)doctor.LicenseNumber  ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UpdatedAt",      (object)doctor.UpdatedAt      ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UpdatedBy_ID",   (object)doctor.UpdatedBy_ID   ?? DBNull.Value);

                await conn.OpenAsync();
                isUpdated = await cmd.ExecuteNonQueryAsync() > 0;
            }
            return isUpdated;
        }

        private static clsDoctor MapDoctor(SqlDataReader reader)
        {
            int specOrd      = reader.GetOrdinal("Specialization");
            int licOrd       = reader.GetOrdinal("LicenseNumber");
            int updatedAtOrd = reader.GetOrdinal("UpdatedAt");
            int updatedByOrd = reader.GetOrdinal("UpdatedBy_ID");

            return new clsDoctor
            {
                DoctorID       = reader.GetInt32(reader.GetOrdinal("DoctorID")),
                Staff_ID       = reader.GetInt32(reader.GetOrdinal("Staff_ID")),
                Specialization = reader.IsDBNull(specOrd)      ? null            : reader.GetString(specOrd),
                LicenseNumber  = reader.IsDBNull(licOrd)       ? null            : reader.GetString(licOrd),
                CreatedAt      = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt      = reader.IsDBNull(updatedAtOrd) ? (DateTime?)null : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID   = reader.IsDBNull(updatedByOrd) ? (int?)null      : reader.GetInt32(updatedByOrd),
            };
        }
    }
}
