using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;
using System.Data.SqlClient;

namespace DentalClinic_DataTier.Repositories
{
    public class BloodTypeRepository : IBloodTypeRepository
    {
        private IDbConnectionFactory _connectionFactory;

        public BloodTypeRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connectionFactory = dbConnectionFactory; 
        }

        public async Task<IEnumerable<clsBloodType>> GetAllBloodTypesAsync()
        {
            var list = new List<clsBloodType>();
            string sql = "SELECT BloodTypeID, BloodTypeName FROM BloodTypes";

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
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

        public async Task<clsBloodType> GetBloodTypeByIdAsync(int bloodTypeId)
        {
            const string sql = "SELECT BloodTypeID, BloodTypeName FROM BloodTypes WHERE BloodTypeID = @BloodTypeID";

            using (var conn = _connectionFactory.CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
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
    }
}
