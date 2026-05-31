using System.Collections.Generic;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Models;
using Microsoft.Data.SqlClient;

namespace DentalClinic_DataTier.Repositories
{
    public class BloodTypeRepository : IBloodTypeRepository
    {
        private readonly string _connectionString;

        public BloodTypeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<clsBloodType>> GetAllBloodTypesAsync()
        {
            var list = new List<clsBloodType>();
            const string sql = "SELECT BloodTypeID, BloodTypeName FROM BloodTypes";

            using (var conn = new SqlConnection(_connectionString))
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

            using (var conn = new SqlConnection(_connectionString))
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
