using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProblemRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddProblemAsync(clsProblem problem)
        {
            try
            {
                int returnedProblemID = -1;
                const string query = @"
                    INSERT INTO Problems
                        (MedicalFile_ID, Diagnosis, TotalCost, ActualPaid, Status, CreationDate)
                    VALUES
                        (@MedicalFile_ID, @Diagnosis, @TotalCost, @ActualPaid, @Status, @CreationDate);
                    SELECT SCOPE_IDENTITY();";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MedicalFile_ID", problem.MedicalFile_ID);
                    cmd.Parameters.AddWithValue("@Diagnosis",      (object)problem.Diagnosis  ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalCost",      (object)problem.TotalCost  ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ActualPaid",     (object)problem.ActualPaid ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status",         problem.Status.ToString());
                    cmd.Parameters.AddWithValue("@CreationDate",   problem.CreationDate);

                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        returnedProblemID = insertedID;
                }
                return returnedProblemID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsProblem> GetProblemByIdAsync(int problemId)
        {
            try
            {
                const string query = @"
                    SELECT ProblemID, MedicalFile_ID, Diagnosis, TotalCost, ActualPaid,
                           Status, CreationDate, UpdatedAt, UpdatedBy_ID
                    FROM Problems
                    WHERE ProblemID = @ProblemID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProblemID", problemId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapProblem(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<clsProblem>> GetProblemsByMedicalFileIdAsync(int medicalFileId)
        {
            try
            {
                const string query = @"
                    SELECT ProblemID, MedicalFile_ID, Diagnosis, TotalCost, ActualPaid,
                           Status, CreationDate, UpdatedAt, UpdatedBy_ID
                    FROM Problems
                    WHERE MedicalFile_ID = @MedicalFile_ID";

                var list = new List<clsProblem>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MedicalFile_ID", medicalFileId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapProblem(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateProblemAsync(clsProblem problem)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE Problems
                    SET MedicalFile_ID = @MedicalFile_ID,
                        Diagnosis      = @Diagnosis,
                        TotalCost      = @TotalCost,
                        ActualPaid     = @ActualPaid,
                        Status         = @Status,
                        UpdatedAt      = @UpdatedAt,
                        UpdatedBy_ID   = @UpdatedBy_ID
                    WHERE ProblemID = @ProblemID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProblemID",      problem.ProblemID);
                    cmd.Parameters.AddWithValue("@MedicalFile_ID", problem.MedicalFile_ID);
                    cmd.Parameters.AddWithValue("@Diagnosis",      (object)problem.Diagnosis    ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalCost",      (object)problem.TotalCost    ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ActualPaid",     (object)problem.ActualPaid   ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status",         problem.Status.ToString());
                    cmd.Parameters.AddWithValue("@UpdatedAt",      (object)problem.UpdatedAt    ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy_ID",   (object)problem.UpdatedBy_ID ?? DBNull.Value);

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

        public async Task<bool> UpdateProblemStatusAsync(int problemId, myEnums.enProblemStatus status, int updatedById)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE Problems
                    SET Status       = @Status,
                        UpdatedAt    = SYSDATETIME(),
                        UpdatedBy_ID = @UpdatedBy_ID
                    WHERE ProblemID = @ProblemID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProblemID",    problemId);
                    cmd.Parameters.AddWithValue("@Status",       status.ToString());
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

        private static clsProblem MapProblem(SqlDataReader reader)
        {
            int diagnosisOrd  = reader.GetOrdinal("Diagnosis");
            int totalCostOrd  = reader.GetOrdinal("TotalCost");
            int actualPaidOrd = reader.GetOrdinal("ActualPaid");
            int updatedAtOrd  = reader.GetOrdinal("UpdatedAt");
            int updatedByOrd  = reader.GetOrdinal("UpdatedBy_ID");

            return new clsProblem
            {
                ProblemID      = reader.GetInt32(reader.GetOrdinal("ProblemID")),
                MedicalFile_ID = reader.GetInt32(reader.GetOrdinal("MedicalFile_ID")),
                Diagnosis      = reader.IsDBNull(diagnosisOrd)  ? null            : reader.GetString(diagnosisOrd),
                TotalCost      = reader.IsDBNull(totalCostOrd)  ? (decimal?)null  : reader.GetDecimal(totalCostOrd),
                ActualPaid     = reader.IsDBNull(actualPaidOrd) ? (decimal?)null  : reader.GetDecimal(actualPaidOrd),
                Status         = (myEnums.enProblemStatus)Enum.Parse(typeof(myEnums.enProblemStatus), reader.GetString(reader.GetOrdinal("Status"))),
                CreationDate   = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                UpdatedAt      = reader.IsDBNull(updatedAtOrd)  ? (DateTime?)null : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID   = reader.IsDBNull(updatedByOrd)  ? (int?)null      : reader.GetInt32(updatedByOrd),
            };
        }
    }
}
