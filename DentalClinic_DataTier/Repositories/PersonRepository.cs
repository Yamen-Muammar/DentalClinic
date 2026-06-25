using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PersonRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddPersonAsync(clsPerson person)
        {
            int returnedPersonID = -1;
            const string query = @"
                INSERT INTO People
                    (FirstName, LastName, SecondName, NationalNo, DateOfBirth, Gender, PhoneNumber, CreatedAt)
                VALUES
                    (@FirstName, @LastName, @SecondName, @NationalNo, @DateOfBirth, @Gender, @PhoneNumber, @CreatedAt);
                SELECT SCOPE_IDENTITY();";

            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName",   person.FirstName);
                cmd.Parameters.AddWithValue("@LastName",    person.LastName);
                cmd.Parameters.AddWithValue("@SecondName",  (object)person.SecondName  ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NationalNo",  (object)person.NationalNo  ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object)person.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender",      person.Gender.ToString());
                cmd.Parameters.AddWithValue("@PhoneNumber", (object)person.PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedAt",   person.CreatedAt);

                await conn.OpenAsync();
                var result = await cmd.ExecuteScalarAsync();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    returnedPersonID = insertedID;
            }
            return returnedPersonID;
        }

        public async Task<clsPerson> GetPersonByIdAsync(int personId)
        {
            const string query = @"
                SELECT PersonID, FirstName, LastName, SecondName, NationalNo,
                       DateOfBirth, Gender, PhoneNumber, CreatedAt, UpdatedAt, UpdatedBy_ID,
                       IsDeleted, DeletedAt, DeletedBy_ID
                FROM People
                WHERE PersonID = @PersonID";

            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PersonID", personId);
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                        return MapPerson(reader);
                }
            }
            return null;
        }

        public async Task<clsPerson> GetPersonByNationalNoAsync(string nationalNo)
        {
            const string query = @"
                SELECT PersonID, FirstName, LastName, SecondName, NationalNo,
                       DateOfBirth, Gender, PhoneNumber, CreatedAt, UpdatedAt, UpdatedBy_ID,
                       IsDeleted, DeletedAt, DeletedBy_ID
                FROM People
                WHERE NationalNo = @NationalNo";

            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NationalNo", nationalNo);
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                        return MapPerson(reader);
                }
            }
            return null;
        }

        public async Task<bool> UpdatePersonAsync(clsPerson person)
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
                    UpdatedAt    = @UpdatedAt,
                    UpdatedBy_ID = @UpdatedBy_ID,
                    IsDeleted = @isDeleted
                WHERE PersonID = @PersonID";

            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PersonID",     person.PersonID);
                cmd.Parameters.AddWithValue("@FirstName",    person.FirstName);
                cmd.Parameters.AddWithValue("@LastName",     person.LastName);
                cmd.Parameters.AddWithValue("@SecondName",   (object)person.SecondName  ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NationalNo",   (object)person.NationalNo  ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth",  (object)person.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender",       person.Gender.ToString());
                cmd.Parameters.AddWithValue("@PhoneNumber",  (object)person.PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UpdatedAt",    (object)person.UpdatedAt    ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UpdatedBy_ID", (object)person.UpdatedBy_ID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@isDeleted", person.IsDeleted);

                await conn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> SoftDeletePersonAsync(int personId, int deletedById)
        {
            const string query = @"
                UPDATE People
                SET IsDeleted    = 1,
                    DeletedAt    = SYSDATETIME(),
                    DeletedBy_ID = @DeletedBy_ID
                WHERE PersonID = @PersonID";

            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PersonID",     personId);
                cmd.Parameters.AddWithValue("@DeletedBy_ID", deletedById);

                await conn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
        }

        private static clsPerson MapPerson(SqlDataReader reader)
        {
            int secondNameOrd  = reader.GetOrdinal("SecondName");
            int nationalNoOrd  = reader.GetOrdinal("NationalNo");
            int dateOfBirthOrd = reader.GetOrdinal("DateOfBirth");
            int phoneOrd       = reader.GetOrdinal("PhoneNumber");
            int updatedAtOrd   = reader.GetOrdinal("UpdatedAt");
            int updatedByOrd   = reader.GetOrdinal("UpdatedBy_ID");
            int deletedAtOrd   = reader.GetOrdinal("DeletedAt");
            int deletedByOrd   = reader.GetOrdinal("DeletedBy_ID");

            return new clsPerson
            {
                PersonID     = reader.GetInt32(reader.GetOrdinal("PersonID")),
                FirstName    = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName     = reader.GetString(reader.GetOrdinal("LastName")),
                SecondName   = reader.IsDBNull(secondNameOrd)  ? null            : reader.GetString(secondNameOrd),
                NationalNo   = reader.IsDBNull(nationalNoOrd)  ? null            : reader.GetString(nationalNoOrd),
                DateOfBirth  = reader.IsDBNull(dateOfBirthOrd) ? (DateTime?)null : reader.GetDateTime(dateOfBirthOrd),
                Gender       = (myEnums.enGenderTypes)Enum.Parse(typeof(myEnums.enGenderTypes), reader.GetString(reader.GetOrdinal("Gender"))),
                PhoneNumber  = reader.IsDBNull(phoneOrd)       ? null            : reader.GetString(phoneOrd),
                CreatedAt    = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt    = reader.IsDBNull(updatedAtOrd)   ? (DateTime?)null : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID = reader.IsDBNull(updatedByOrd)   ? (int?)null      : reader.GetInt32(updatedByOrd),
                IsDeleted    = reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                DeletedAt    = reader.IsDBNull(deletedAtOrd)   ? (DateTime?)null : reader.GetDateTime(deletedAtOrd),
                DeletedBy_ID = reader.IsDBNull(deletedByOrd)   ? (int?)null      : reader.GetInt32(deletedByOrd),
            };
        }
    }
}
