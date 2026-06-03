using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
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
            try
            {
                int returnedPersonID = -1;
                const string query = @"
                    INSERT INTO Persons
                        (FirstName, LastName, SecondName, NationalNo, DateOfBirth, Gender, CreatedAt)
                    VALUES
                        (@FirstName, @LastName, @SecondName, @NationalNo, @DateOfBirth, @Gender, @CreatedAt);
                    SELECT SCOPE_IDENTITY();";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName",   person.FirstName);
                    cmd.Parameters.AddWithValue("@LastName",    person.LastName);
                    cmd.Parameters.AddWithValue("@SecondName",  (object)person.SecondName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NationalNo",  (object)person.NationalNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender",      person.Gender);
                    cmd.Parameters.AddWithValue("@CreatedAt",   person.CreatedAt);

                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        returnedPersonID = insertedID;
                }
                return returnedPersonID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsPerson> GetPersonByIdAsync(int personId)
        {
            try
            {
                const string query = @"
                    SELECT PersonID, FirstName, LastName, SecondName, NationalNo,
                           DateOfBirth, Gender, CreatedAt, UpdatedAt, UpdatedBy_ID,
                           IsDeleted, DeletedAt, DeletedBy_ID
                    FROM Persons
                    WHERE PersonID = @PersonID AND IsDeleted = 0";

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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsPerson> GetPersonByNationalNoAsync(string nationalNo)
        {
            try
            {
                const string query = @"
                    SELECT PersonID, FirstName, LastName, SecondName, NationalNo,
                           DateOfBirth, Gender, CreatedAt, UpdatedAt, UpdatedBy_ID,
                           IsDeleted, DeletedAt, DeletedBy_ID
                    FROM Persons
                    WHERE NationalNo = @NationalNo AND IsDeleted = 0";

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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePersonAsync(clsPerson person)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE Persons
                    SET FirstName    = @FirstName,
                        LastName     = @LastName,
                        SecondName   = @SecondName,
                        NationalNo   = @NationalNo,
                        DateOfBirth  = @DateOfBirth,
                        Gender       = @Gender,
                        UpdatedAt    = @UpdatedAt,
                        UpdatedBy_ID = @UpdatedBy_ID
                    WHERE PersonID = @PersonID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonID",     person.PersonID);
                    cmd.Parameters.AddWithValue("@FirstName",    person.FirstName);
                    cmd.Parameters.AddWithValue("@LastName",     person.LastName);
                    cmd.Parameters.AddWithValue("@SecondName",   (object)person.SecondName  ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NationalNo",   (object)person.NationalNo  ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth",  person.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender",       person.Gender);
                    cmd.Parameters.AddWithValue("@UpdatedAt",    (object)person.UpdatedAt    ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy_ID", (object)person.UpdatedBy_ID ?? DBNull.Value);

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

        public async Task<bool> SoftDeletePersonAsync(int personId, int deletedById)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE Persons
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
                    isUpdated = await cmd.ExecuteNonQueryAsync() > 0;
                }
                return isUpdated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> AddPhoneNumberAsync(clsPhoneNumber phoneNumber)
        {
            try
            {
                int returnedPhoneNumberID = -1;
                const string query = @"
                    INSERT INTO PhoneNumbers
                        (Person_ID, Number, IsPrimary, IsActive, CreatedAt)
                    VALUES
                        (@Person_ID, @Number, @IsPrimary, @IsActive, @CreatedAt);
                    SELECT SCOPE_IDENTITY();";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Person_ID",  phoneNumber.Person_ID);
                    cmd.Parameters.AddWithValue("@Number",     phoneNumber.Number);
                    cmd.Parameters.AddWithValue("@IsPrimary",  phoneNumber.IsPrimary);
                    cmd.Parameters.AddWithValue("@IsActive",   phoneNumber.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedAt",  phoneNumber.CreatedAt);

                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        returnedPhoneNumberID = insertedID;
                }
                return returnedPhoneNumberID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsPhoneNumber> GetPhoneNumberByIdAsync(int phoneNumberId)
        {
            try
            {
                const string query = @"
                    SELECT PhoneNumberID, Person_ID, Number, IsPrimary, IsActive, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM PhoneNumbers
                    WHERE PhoneNumberID = @PhoneNumberID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumberID", phoneNumberId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapPhoneNumber(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<clsPhoneNumber>> GetPhoneNumbersByPersonIdAsync(int personId)
        {
            try
            {
                const string query = @"
                    SELECT PhoneNumberID, Person_ID, Number, IsPrimary, IsActive, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM PhoneNumbers
                    WHERE Person_ID = @Person_ID";

                var list = new List<clsPhoneNumber>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Person_ID", personId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapPhoneNumber(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePhoneNumberAsync(clsPhoneNumber phoneNumber)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE PhoneNumbers
                    SET Person_ID    = @Person_ID,
                        Number       = @Number,
                        IsPrimary    = @IsPrimary,
                        IsActive     = @IsActive,
                        UpdatedAt    = @UpdatedAt,
                        UpdatedBy_ID = @UpdatedBy_ID
                    WHERE PhoneNumberID = @PhoneNumberID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumberID", phoneNumber.PhoneNumberID);
                    cmd.Parameters.AddWithValue("@Person_ID",     phoneNumber.Person_ID);
                    cmd.Parameters.AddWithValue("@Number",        phoneNumber.Number);
                    cmd.Parameters.AddWithValue("@IsPrimary",     phoneNumber.IsPrimary);
                    cmd.Parameters.AddWithValue("@IsActive",      phoneNumber.IsActive);
                    cmd.Parameters.AddWithValue("@UpdatedAt",     (object)phoneNumber.UpdatedAt    ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy_ID",  (object)phoneNumber.UpdatedBy_ID ?? DBNull.Value);

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

        public async Task<bool> ChangeActiveStatusAsync(int phoneNumberId, bool isActive, int updatedById)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE PhoneNumbers
                    SET IsActive     = @IsActive,
                        UpdatedAt    = SYSDATETIME(),
                        UpdatedBy_ID = @UpdatedBy_ID
                    WHERE PhoneNumberID = @PhoneNumberID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumberID", phoneNumberId);
                    cmd.Parameters.AddWithValue("@IsActive",      isActive);
                    cmd.Parameters.AddWithValue("@UpdatedBy_ID",  updatedById);

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

        public async Task<bool> SetAllPersonNumbersNonPrimaryAsync(int personId, int updatedById)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE PhoneNumbers
                    SET IsPrimary    = 0,
                        UpdatedAt    = SYSDATETIME(),
                        UpdatedBy_ID = @UpdatedBy_ID
                    WHERE Person_ID = @Person_ID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Person_ID",    personId);
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

        private static clsPerson MapPerson(SqlDataReader reader)
        {
            int secondNameOrd = reader.GetOrdinal("SecondName");
            int nationalNoOrd = reader.GetOrdinal("NationalNo");
            int updatedAtOrd  = reader.GetOrdinal("UpdatedAt");
            int updatedByOrd  = reader.GetOrdinal("UpdatedBy_ID");
            int deletedAtOrd  = reader.GetOrdinal("DeletedAt");
            int deletedByOrd  = reader.GetOrdinal("DeletedBy_ID");

            return new clsPerson
            {
                PersonID     = reader.GetInt32(reader.GetOrdinal("PersonID")),
                FirstName    = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName     = reader.GetString(reader.GetOrdinal("LastName")),
                SecondName   = reader.IsDBNull(secondNameOrd) ? null            : reader.GetString(secondNameOrd),
                NationalNo   = reader.IsDBNull(nationalNoOrd) ? null            : reader.GetString(nationalNoOrd),
                DateOfBirth  = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                Gender       = reader.GetString(reader.GetOrdinal("Gender"))[0],
                CreatedAt    = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt    = reader.IsDBNull(updatedAtOrd)  ? (DateTime?)null : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID = reader.IsDBNull(updatedByOrd)  ? (int?)null      : reader.GetInt32(updatedByOrd),
                IsDeleted    = reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                DeletedAt    = reader.IsDBNull(deletedAtOrd)  ? (DateTime?)null : reader.GetDateTime(deletedAtOrd),
                DeletedBy_ID = reader.IsDBNull(deletedByOrd)  ? (int?)null      : reader.GetInt32(deletedByOrd),
            };
        }

        private static clsPhoneNumber MapPhoneNumber(SqlDataReader reader)
        {
            int updatedAtOrd = reader.GetOrdinal("UpdatedAt");
            int updatedByOrd = reader.GetOrdinal("UpdatedBy_ID");

            return new clsPhoneNumber
            {
                PhoneNumberID = reader.GetInt32(reader.GetOrdinal("PhoneNumberID")),
                Person_ID     = reader.GetInt32(reader.GetOrdinal("Person_ID")),
                Number        = reader.GetString(reader.GetOrdinal("Number")),
                IsPrimary     = reader.GetBoolean(reader.GetOrdinal("IsPrimary")),
                IsActive      = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                CreatedAt     = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt     = reader.IsDBNull(updatedAtOrd) ? (DateTime?)null : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID  = reader.IsDBNull(updatedByOrd) ? (int?)null      : reader.GetInt32(updatedByOrd),
            };
        }
    }
}
