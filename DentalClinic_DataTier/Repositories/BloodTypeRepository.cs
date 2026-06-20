using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class BloodTypeRepository : IBloodTypeRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BloodTypeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<clsBloodType>> GetAllBloodTypesAsync()
        {
            try
            {
                var list = new List<clsBloodType>();
                const string query = "SELECT BloodTypeID, BloodTypeName FROM BloodTypes Order by BloodTypeID ASC";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new clsBloodType
                            {
                                BloodTypeID   = reader.GetInt32(reader.GetOrdinal("BloodTypeID")),
                                BloodTypeName = reader.GetString(reader.GetOrdinal("BloodTypeName"))
                            });
                        }
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsBloodType> GetBloodTypeByIdAsync(int bloodTypeId)
        {
            try
            {
                const string query = "SELECT BloodTypeID, BloodTypeName FROM BloodTypes WHERE BloodTypeID = @BloodTypeID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BloodTypeID", bloodTypeId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new clsBloodType
                            {
                                BloodTypeID   = reader.GetInt32(reader.GetOrdinal("BloodTypeID")),
                                BloodTypeName = reader.GetString(reader.GetOrdinal("BloodTypeName"))
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
