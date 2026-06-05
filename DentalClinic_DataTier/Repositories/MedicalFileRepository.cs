using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class MedicalFileRepository : IMedicalFileRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public MedicalFileRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddMedicalFileAsync(clsMedicalFile medicalFile)
        {
            try
            {
                int returnedMedicalFileID = -1;
                const string query = @"
                    INSERT INTO MedicalFiles
                        (Patient_ID, GeneralAllergies, CreationDate)
                    VALUES
                        (@Patient_ID, @GeneralAllergies, @CreationDate);
                    SELECT SCOPE_IDENTITY();";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Patient_ID",       medicalFile.Patient_ID);
                    cmd.Parameters.AddWithValue("@GeneralAllergies", (object)medicalFile.GeneralAllergies ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreationDate",     medicalFile.CreationDate);

                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        returnedMedicalFileID = insertedID;
                }
                return returnedMedicalFileID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsMedicalFile> GetMedicalFileByIdAsync(int fileId)
        {
            try
            {
                const string query = @"
                    SELECT MedicalFileID, Patient_ID, GeneralAllergies, CreationDate, UpdatedAt, UpdatedBy_ID
                    FROM MedicalFiles
                    WHERE MedicalFileID = @MedicalFileID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MedicalFileID", fileId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapMedicalFile(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsMedicalFile> GetMedicalFileByPatientIdAsync(int patientId)
        {
            try
            {
                const string query = @"
                    SELECT MedicalFileID, Patient_ID, GeneralAllergies, CreationDate, UpdatedAt, UpdatedBy_ID
                    FROM MedicalFiles
                    WHERE Patient_ID = @Patient_ID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Patient_ID", patientId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapMedicalFile(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateMedicalFileAsync(clsMedicalFile medicalFile)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE MedicalFiles
                    SET GeneralAllergies = @GeneralAllergies,
                        UpdatedAt        = @UpdatedAt,
                        UpdatedBy_ID     = @UpdatedBy_ID
                    WHERE MedicalFileID = @MedicalFileID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MedicalFileID",    medicalFile.MedicalFileID);
                    cmd.Parameters.AddWithValue("@GeneralAllergies", (object)medicalFile.GeneralAllergies ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedAt",        (object)medicalFile.UpdatedAt        ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy_ID",     (object)medicalFile.UpdatedBy_ID     ?? DBNull.Value);

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

        private static clsMedicalFile MapMedicalFile(SqlDataReader reader)
        {
            int allergiesOrd = reader.GetOrdinal("GeneralAllergies");
            int updatedAtOrd = reader.GetOrdinal("UpdatedAt");
            int updatedByOrd = reader.GetOrdinal("UpdatedBy_ID");

            return new clsMedicalFile
            {
                MedicalFileID    = reader.GetInt32(reader.GetOrdinal("MedicalFileID")),
                Patient_ID       = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                GeneralAllergies = reader.IsDBNull(allergiesOrd) ? null            : reader.GetString(allergiesOrd),
                CreationDate     = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                UpdatedAt        = reader.IsDBNull(updatedAtOrd) ? (DateTime?)null : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID     = reader.IsDBNull(updatedByOrd) ? (int?)null      : reader.GetInt32(updatedByOrd),
            };
        }
    }
}
