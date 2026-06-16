using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;

namespace DentalClinic_DataTier.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PatientRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddPatientAsync(clsPatient patient)
        {
            try
            {
                int returnedPatientID = -1;
                const string query = @"
                    INSERT INTO Patients (Person_ID, BloodType_ID, HealthProblems, CreatedAt)
                    VALUES (@Person_ID, @BloodType_ID, @HealthProblems, @CreatedAt);
                    SELECT SCOPE_IDENTITY();";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Person_ID",      patient.Person_ID);
                    cmd.Parameters.AddWithValue("@BloodType_ID",   (object)patient.BloodType_ID   ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HealthProblems", (object)patient.HealthProblems ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt",      patient.CreatedAt);

                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        returnedPatientID = insertedID;
                }
                return returnedPatientID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsPatient> GetPatientByIdAsync(int patientId)
        {
            try
            {
                const string query = @"
                    SELECT PatientID, Person_ID, BloodType_ID, HealthProblems, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM Patients
                    WHERE PatientID = @PatientID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapPatient(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsPatient> GetPatientByPersonIdAsync(int personId)
        {
            try
            {
                const string query = @"
                    SELECT PatientID, Person_ID, BloodType_ID, HealthProblems, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM Patients
                    WHERE Person_ID = @Person_ID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Person_ID", personId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapPatient(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<clsPatient>> GetAllPatientsAsync()
        {
            try
            {
                const string query = @"
                    SELECT PatientID, Person_ID, BloodType_ID, HealthProblems, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM Patients";

                var list = new List<clsPatient>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapPatient(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePatientAsync(clsPatient patient)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE Patients
                    SET Person_ID      = @Person_ID,
                        BloodType_ID   = @BloodType_ID,
                        HealthProblems = @HealthProblems,
                        UpdatedAt      = @UpdatedAt,
                        UpdatedBy_ID   = @UpdatedBy_ID
                    WHERE PatientID = @PatientID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID",      patient.PatientID);
                    cmd.Parameters.AddWithValue("@Person_ID",      patient.Person_ID);
                    cmd.Parameters.AddWithValue("@BloodType_ID",   (object)patient.BloodType_ID   ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HealthProblems", (object)patient.HealthProblems ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedAt",      (object)patient.UpdatedAt      ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy_ID",   (object)patient.UpdatedBy_ID   ?? DBNull.Value);

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

        public async Task<IEnumerable<clsPatient>> SearchByFullNameAsync(string fullName)
        {
            try
            {
                const string query = @"
                    SELECT p.PatientID, p.Person_ID, p.BloodType_ID, p.HealthProblems,
                           p.CreatedAt, p.UpdatedAt, p.UpdatedBy_ID
                    FROM Patients p
                    INNER JOIN People pe ON p.Person_ID = pe.PersonID
                    WHERE (pe.FirstName + ' ' + pe.LastName) LIKE @FullName
                      AND pe.IsDeleted = 0;";
                var list = new List<clsPatient>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", "%" + fullName + "%");
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                        while (await reader.ReadAsync())
                            list.Add(MapPatient(reader));
                }
                return list;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<clsPatient>> SearchByNationalNoAsync(string nationalNo)
        {
            try
            {
                const string query = @"
                    SELECT p.PatientID, p.Person_ID, p.BloodType_ID, p.HealthProblems,
                           p.CreatedAt, p.UpdatedAt, p.UpdatedBy_ID
                    FROM Patients p
                    INNER JOIN People pe ON p.Person_ID = pe.PersonID
                    WHERE pe.NationalNo LIKE @NationalNo
                      AND pe.IsDeleted = 0";
                var list = new List<clsPatient>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NationalNo", "%" + nationalNo + "%");
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                        while (await reader.ReadAsync())
                            list.Add(MapPatient(reader));
                }
                return list;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<clsPatient>> SearchByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                const string query = @"
                    SELECT DISTINCT p.PatientID, p.Person_ID, p.BloodType_ID, p.HealthProblems,
                           p.CreatedAt, p.UpdatedAt, p.UpdatedBy_ID
                    FROM Patients p
                    INNER JOIN People pe ON p.Person_ID = pe.PersonID
                    INNER JOIN PhoneNumbers ph ON pe.PersonID = ph.Person_ID
                    WHERE ph.Number LIKE @PhoneNumber
                      AND ph.IsActive = 1
                      AND pe.IsDeleted = 0";
                var list = new List<clsPatient>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumber", "%" + phoneNumber + "%");
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                        while (await reader.ReadAsync())
                            list.Add(MapPatient(reader));
                }
                return list;
            }
            catch (Exception) { throw; }
        }

        private static clsPatient MapPatient(SqlDataReader reader)
        {
            int bloodTypeOrd = reader.GetOrdinal("BloodType_ID");
            int healthOrd    = reader.GetOrdinal("HealthProblems");
            int updatedAtOrd = reader.GetOrdinal("UpdatedAt");
            int updatedByOrd = reader.GetOrdinal("UpdatedBy_ID");

            return new clsPatient
            {
                PatientID      = reader.GetInt32(reader.GetOrdinal("PatientID")),
                Person_ID      = reader.GetInt32(reader.GetOrdinal("Person_ID")),
                BloodType_ID   = reader.IsDBNull(bloodTypeOrd) ? (int?)null      : reader.GetInt32(bloodTypeOrd),
                HealthProblems = reader.IsDBNull(healthOrd)    ? null            : reader.GetString(healthOrd),
                CreatedAt      = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt      = reader.IsDBNull(updatedAtOrd) ? (DateTime?)null : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID   = reader.IsDBNull(updatedByOrd) ? (int?)null      : reader.GetInt32(updatedByOrd),
            };
        }

        public async Task<IEnumerable<clsPatientView>> GetAllPatientDetailsAsync()
        {
            try
            {
                const string query =
                    "SELECT PatientID, FullName, Age, Gender, PhoneNumber, BloodType FROM vw_PatientDetails";

                var list = new List<clsPatientView>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                        while (await reader.ReadAsync())
                            list.Add(MapPatientView(reader));
                }
                return list;
            }
            catch (Exception) { throw; }
        }

        private static clsPatientView MapPatientView(SqlDataReader reader)
        {
            return new clsPatientView
            {
                ID            = reader.GetInt32(reader.GetOrdinal("PatientID")),
                FullName      = reader.GetString(reader.GetOrdinal("FullName")),
                Age           = reader.GetString(reader.GetOrdinal("Age")),
                Gender        = reader.GetString(reader.GetOrdinal("Gender")),
                PhoneNumber   = reader.GetString(reader.GetOrdinal("Number")),
                BloodTypeName = reader.GetString(reader.GetOrdinal("BloodTypeName")),
            };
        }
    }
}
