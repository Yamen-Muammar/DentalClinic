using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            int returnedPatientID = -1;
            const string query = @"
                INSERT INTO Patients (Person_ID, BloodType_ID, HealthProblems, CreatedAt)
                VALUES (@Person_ID, @BloodType_ID, @HealthProblems, @CreatedAt);
                SELECT SCOPE_IDENTITY();";
            try
            {
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Person_ID", patient.Person_ID);
                    cmd.Parameters.AddWithValue("@BloodType_ID", (object)patient.BloodType_ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HealthProblems", (object)patient.HealthProblems ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", patient.CreatedAt);

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

        public async Task<int> AddPatientWithPersonAndMedicalFileAsync(clsPatient patient,clsMedicalFile medicalFile)
        {
            int returnedPatientID = -1;
            try
            {
                using (var conn = _connectionFactory.CreateConnection())
                {
                    await conn.OpenAsync();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            int personId = await _insertPersonAsync(conn, transaction, patient.PersonInfo);
                            patient.Person_ID = personId;

                            returnedPatientID = await _insertPatientAsync(conn, transaction, patient);
                            medicalFile.Patient_ID = returnedPatientID;

                            int returnMedicalFileID = await _insertMedicalFileAsync(conn, transaction, medicalFile);
                            medicalFile.MedicalFileID = returnMedicalFileID;

                            transaction.Commit();
                            return returnedPatientID;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private async Task<int> _insertPersonAsync(SqlConnection conn, SqlTransaction transaction, clsPerson person)
        {
            int personId = -1;
            const string query = @"
                INSERT INTO People
                    (FirstName, LastName, SecondName, NationalNo, DateOfBirth, Gender, PhoneNumber, CreatedAt)
                VALUES
                    (@FirstName, @LastName, @SecondName, @NationalNo, @DateOfBirth, @Gender, @PhoneNumber, @CreatedAt);
                SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@FirstName",   person.FirstName);
                cmd.Parameters.AddWithValue("@LastName",    person.LastName);
                cmd.Parameters.AddWithValue("@SecondName",  (object)person.SecondName  ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NationalNo",  (object)person.NationalNo  ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object)person.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender",      person.Gender.ToString());
                cmd.Parameters.AddWithValue("@PhoneNumber", (object)person.PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedAt",   person.CreatedAt);

                var result = await cmd.ExecuteScalarAsync();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    personId = insertedID;
            }
            return personId;
        }

        private async Task<int> _insertPatientAsync(SqlConnection conn, SqlTransaction transaction, clsPatient patient)
        {
            int patientId = -1;
            const string query = @"
                INSERT INTO Patients (Person_ID, BloodType_ID, HealthProblems, CreatedAt)
                VALUES (@Person_ID, @BloodType_ID, @HealthProblems, @CreatedAt);
                SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Person_ID",      patient.Person_ID);
                cmd.Parameters.AddWithValue("@BloodType_ID",   (object)patient.BloodType_ID   ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HealthProblems", (object)patient.HealthProblems ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedAt",      patient.CreatedAt);

                var result = await cmd.ExecuteScalarAsync();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    patientId = insertedID;
            }
            return patientId;
        }

        private async Task<int> _insertMedicalFileAsync(SqlConnection conn, SqlTransaction transaction, clsMedicalFile medicalFile)
        {
            int insertedMedicalFileId = -1;
            const string query = @"
                    INSERT INTO MedicalFiles
                    (Patient_ID, GeneralAllergies, CreationDate)
                     VALUES
                    (@Patient_ID, @GeneralAllergies, @CreationDate);
                    SELECT SCOPE_IDENTITY();";
            using (var cmd = new SqlCommand(query, conn,transaction))
            {
                cmd.Parameters.AddWithValue("@Patient_ID", medicalFile.Patient_ID);
                cmd.Parameters.AddWithValue("@GeneralAllergies", (object)medicalFile.GeneralAllergies ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CreationDate", medicalFile.CreationDate);

                var result = await cmd.ExecuteScalarAsync();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    insertedMedicalFileId = insertedID;
            }
            return insertedMedicalFileId;
        }
        public async Task<clsPatient> GetPatientByIdAsync(int patientId)
        {
            const string query = @"
                SELECT PatientID, Person_ID, BloodType_ID, HealthProblems, CreatedAt, UpdatedAt, UpdatedBy_ID
                FROM Patients
                WHERE PatientID = @PatientID";
            try
            {
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
            const string query = @"
                SELECT PatientID, Person_ID, BloodType_ID, HealthProblems, CreatedAt, UpdatedAt, UpdatedBy_ID
                FROM Patients
                WHERE Person_ID = @Person_ID";
            try
            {
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
            const string query = @"
                SELECT PatientID, Person_ID, BloodType_ID, HealthProblems, CreatedAt, UpdatedAt, UpdatedBy_ID
                FROM Patients";

            var list = new List<clsPatient>();
            try
            {
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                        while (await reader.ReadAsync())
                            list.Add(MapPatient(reader));
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
            const string query = @"
                UPDATE Patients
                SET Person_ID      = @Person_ID,
                    BloodType_ID   = @BloodType_ID,
                    HealthProblems = @HealthProblems,
                    UpdatedAt      = @UpdatedAt,
                    UpdatedBy_ID   = @UpdatedBy_ID
                WHERE PatientID = @PatientID";

            try
            {
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patient.PatientID);
                    cmd.Parameters.AddWithValue("@Person_ID", patient.Person_ID);
                    cmd.Parameters.AddWithValue("@BloodType_ID", (object)patient.BloodType_ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HealthProblems", (object)patient.HealthProblems ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedAt", (object)patient.UpdatedAt ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy_ID", (object)patient.UpdatedBy_ID ?? DBNull.Value);

                    await conn.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<bool> UpdatePatientWithPersonAndMedicalFileAsync(clsPatient patient,clsMedicalFile medicalFile)
        {
            try
            {
                using (var conn = _connectionFactory.CreateConnection())
                {
                    await conn.OpenAsync();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            await _updatePersonAsync(conn, transaction, patient.PersonInfo);
                            await _updatePatientAsync(conn, transaction, patient);
                            await _updateMedicalFileAsync(conn, transaction, medicalFile);
                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }  
        }

        private async Task _updatePersonAsync(SqlConnection conn, SqlTransaction transaction, clsPerson person)
        {
            const string query = @"
                UPDATE People
                SET FirstName    = @FirstName,
                    LastName     = @LastName,
                    SecondName   = @SecondName,
                    NationalNo   = @NationalNo,
                    DateOfBirth  = @DateOfBirth,
                    Gender       = @Gender,
                    PhoneNumber  = @PhoneNumber,
                    UpdatedAt    = SYSDATETIME(),
                    UpdatedBy_ID = @UpdatedBy_ID
                WHERE PersonID = @PersonID";

            using (var cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@PersonID",    person.PersonID);
                cmd.Parameters.AddWithValue("@FirstName",   person.FirstName);
                cmd.Parameters.AddWithValue("@LastName",    person.LastName);
                cmd.Parameters.AddWithValue("@SecondName",  (object)person.SecondName  ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NationalNo",  (object)person.NationalNo  ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object)person.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender",      person.Gender.ToString());
                cmd.Parameters.AddWithValue("@PhoneNumber", (object)person.PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UpdatedBy_ID", person.UpdatedBy_ID);
                await cmd.ExecuteNonQueryAsync();
            }
        }
        private async Task _updatePatientAsync(SqlConnection conn, SqlTransaction transaction, clsPatient patient)
        {
            const string query = @"
                UPDATE Patients
                SET BloodType_ID   = @BloodType_ID,
                    HealthProblems = @HealthProblems,
                    UpdatedAt      = SYSDATETIME(),
                    UpdatedBy_ID   = @UpdatedBy_ID
                WHERE PatientID = @PatientID";

            using (var cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@PatientID",      patient.PatientID);
                cmd.Parameters.AddWithValue("@BloodType_ID",   (object)patient.BloodType_ID   ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HealthProblems", (object)patient.HealthProblems ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UpdatedBy_ID",   patient.UpdatedBy_ID);
                await cmd.ExecuteNonQueryAsync();
            }
        }
        private async Task _updateMedicalFileAsync(SqlConnection conn, SqlTransaction transaction,clsMedicalFile medicalFile)
        {
            const string query = @"
                UPDATE MedicalFiles SET
                     GeneralAllergies =  @GeneralAllergies
                WHERE Patient_ID = @patient_ID";

            using (var cmd = new SqlCommand(query, conn,transaction))
            {         
                cmd.Parameters.AddWithValue("@GeneralAllergies", (object)medicalFile.GeneralAllergies ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@patient_ID", medicalFile.Patient_ID);
                await cmd.ExecuteNonQueryAsync();

            }
        }
        public async Task<IEnumerable<clsPatient>> SearchByFullNameAsync(string fullName)
        {
            const string query = @"
                SELECT p.PatientID, p.Person_ID, p.BloodType_ID, p.HealthProblems,
                       p.CreatedAt, p.UpdatedAt, p.UpdatedBy_ID
                FROM Patients p
                INNER JOIN People pe ON p.Person_ID = pe.PersonID
                WHERE (pe.FirstName + ' ' + pe.LastName) LIKE @FullName;";

            var list = new List<clsPatient>();
            try
            {
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
            catch (Exception)
            {

                throw;
            }
            
        }
        public async Task<IEnumerable<clsPatient>> SearchByNationalNoAsync(string nationalNo)
        {
            const string query = @"
                SELECT p.PatientID, p.Person_ID, p.BloodType_ID, p.HealthProblems,
                       p.CreatedAt, p.UpdatedAt, p.UpdatedBy_ID
                FROM Patients p
                INNER JOIN People pe ON p.Person_ID = pe.PersonID
                WHERE pe.NationalNo LIKE @NationalNo
                  AND pe.IsDeleted = 0";

            var list = new List<clsPatient>();
            try
            {
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
            catch (Exception)
            {

                throw;
            }
         
        }
        public async Task<IEnumerable<clsPatient>> SearchByPhoneNumberAsync(string phoneNumber)
        {
            const string query = @"
                SELECT p.PatientID, p.Person_ID, p.BloodType_ID, p.HealthProblems,
                       p.CreatedAt, p.UpdatedAt, p.UpdatedBy_ID
                FROM Patients p
                INNER JOIN People pe ON p.Person_ID = pe.PersonID
                WHERE pe.PhoneNumber LIKE @PhoneNumber
                  AND pe.IsDeleted = 0";

            var list = new List<clsPatient>();
            try
            {
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
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> GetPatientCountAsync()
        {
            const string query = "SELECT COUNT(PatientID) From vw_PatientDetails";
            int count = -1;

            try
            {
                using(SqlConnection conn = _connectionFactory.CreateConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    object result = await cmd.ExecuteScalarAsync();
                    if (result != null && result is int)
                    {
                        return (int)result;
                    }
                }
                   
            }
            catch (Exception)
            { 
                throw;
            }
            return count;
        }
        public async Task<clsPatientView> GetPatientDetailsViewByIDAsync(int patientID)
        {
            const string query =
                "SELECT PatientID, FullName, Age, Gender, PhoneNumber, BloodType FROM vw_PatientDetails WHERE PatientID = @PatientID";

            clsPatientView patientView = null;
            try
            {
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                        if (await reader.ReadAsync())
                            patientView = MapPatientView(reader);
                }
                return patientView;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<clsPatientView>> GetAllPatientDetailsAsync()
        {
            const string query =
                "SELECT PatientID, FullName, Age, Gender, PhoneNumber, BloodType FROM vw_PatientDetails";

            var list = new List<clsPatientView>();
            try
            {
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
            catch (Exception)
            {

                throw;
            }
           
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
                HealthProblems = reader.IsDBNull(healthOrd)    ? null             : reader.GetString(healthOrd),
                CreatedAt      = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt      = reader.IsDBNull(updatedAtOrd) ? (DateTime?)null  : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID   = reader.IsDBNull(updatedByOrd) ? (int?)null       : reader.GetInt32(updatedByOrd),
            };
        }
        private static clsPatientView MapPatientView(SqlDataReader reader)
        {
            int phoneOrd     = reader.GetOrdinal("PhoneNumber");
            int bloodTypeOrd = reader.GetOrdinal("BloodType");

            return new clsPatientView
            {
                ID            = reader.GetInt32(reader.GetOrdinal("PatientID")),
                FullName      = reader.GetString(reader.GetOrdinal("FullName")),
                Age           = (reader.GetInt32(reader.GetOrdinal("Age")).ToString()== "-1" )? "N/A":reader.GetInt32(reader.GetOrdinal("Age")).ToString(),                
                Gender        = reader.GetString(reader.GetOrdinal("Gender")),
                PhoneNumber   = reader.IsDBNull(phoneOrd)     ? string.Empty : reader.GetString(phoneOrd),
                BloodTypeName = reader.IsDBNull(bloodTypeOrd) ? string.Empty : reader.GetString(bloodTypeOrd),
            };
        }

      
    }
}
