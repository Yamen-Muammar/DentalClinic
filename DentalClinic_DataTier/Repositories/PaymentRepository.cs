using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;

namespace DentalClinic_DataTier.Repositories
{
    public class PaymentRepository : IPaymentRepository, IPaymentDestinationRepository, IPaymentTypeRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PaymentRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddPaymentAsync(clsPayment payment)
        {
            try
            {
                int returnedPaymentID = -1;
                const string query = @"
                    INSERT INTO Payments
                        (PaymentType_ID, PaymentDestination_ID, Appointment_ID, CreatedBy_ID, IsApproved, SenderNumber, Amount, CreatedAt)
                    VALUES
                        (@PaymentType_ID, @PaymentDestination_ID, @Appointment_ID, @CreatedBy_ID, @IsApproved, @SenderNumber, @Amount, @CreatedAt);
                    SELECT SCOPE_IDENTITY();";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentType_ID",        payment.PaymentType_ID);
                    cmd.Parameters.AddWithValue("@PaymentDestination_ID", payment.PaymentDestination_ID);
                    cmd.Parameters.AddWithValue("@Appointment_ID",        payment.Appointment_ID);
                    cmd.Parameters.AddWithValue("@CreatedBy_ID",          payment.CreatedBy_ID);
                    cmd.Parameters.AddWithValue("@IsApproved",            payment.IsApproved);
                    if (payment.SenderNumber != null)
                    {
                        cmd.Parameters.AddWithValue("@SenderNumber",      payment.SenderNumber);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SenderNumber", DBNull.Value); 
                    }
                    cmd.Parameters.AddWithValue("@Amount",                payment.Amount);
                    cmd.Parameters.AddWithValue("@CreatedAt",             payment.CreatedAt);

                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        returnedPaymentID = insertedID;
                }
                return returnedPaymentID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsPayment> GetPaymentByIdAsync(int paymentId)
        {
            try
            {
                const string query = @"
                    SELECT PaymentID, PaymentType_ID, PaymentDestination_ID, Appointment_ID,
                           CreatedBy_ID, IsApproved, SenderNumber, Amount, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM Payments
                    WHERE PaymentID = @PaymentID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentID", paymentId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapPayment(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<clsPayment>> GetPaymentsByAppointmentIdAsync(int appointmentId)
        {
            try
            {
                const string query = @"
                    SELECT PaymentID, PaymentType_ID, PaymentDestination_ID, Appointment_ID,
                           CreatedBy_ID, IsApproved, SenderNumber, Amount, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM Payments
                    WHERE Appointment_ID = @Appointment_ID";

                var list = new List<clsPayment>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Appointment_ID", appointmentId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapPayment(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<clsPayment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                const string query = @"
                    SELECT PaymentID, PaymentType_ID, PaymentDestination_ID, Appointment_ID,
                           CreatedBy_ID, IsApproved, SenderNumber, Amount, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM Payments
                    WHERE CreatedAt BETWEEN @StartDate AND @EndDate";

                var list = new List<clsPayment>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate",   endDate);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapPayment(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePaymentApprovalAsync(int paymentId, bool isApproved, int updatedById)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE Payments
                    SET IsApproved   = @IsApproved,
                        UpdatedAt    = SYSDATETIME(),
                        UpdatedBy_ID = @UpdatedBy_ID
                    WHERE PaymentID = @PaymentID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentID",    paymentId);
                    cmd.Parameters.AddWithValue("@IsApproved",   isApproved);
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

        public async Task<IEnumerable<clsPaymentType>> GetAllPaymentTypesAsync()
        {
            try
            {
                const string query = "SELECT PaymentTypeID, PaymentTypeName FROM PaymentTypes";

                var list = new List<clsPaymentType>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapPaymentType(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsPaymentType> GetPaymentTypeByIdAsync(int paymentTypeId)
        {
            try
            {
                const string query = "SELECT PaymentTypeID, PaymentTypeName FROM PaymentTypes WHERE PaymentTypeID = @PaymentTypeID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentTypeID", paymentTypeId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapPaymentType(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<clsPaymentDestination>> GetAllPaymentDestinationsAsync()
        {
            try
            {
                const string query = "SELECT PaymentDestinationID, PaymentDestinationName FROM PaymentDestinations";

                var list = new List<clsPaymentDestination>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapPaymentDestination(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsPaymentDestination> GetPaymentDestinationByIdAsync(int destinationId)
        {
            try
            {
                const string query = "SELECT PaymentDestinationID, PaymentDestinationName FROM PaymentDestinations WHERE PaymentDestinationID = @PaymentDestinationID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentDestinationID", destinationId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapPaymentDestination(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static clsPayment MapPayment(SqlDataReader reader)
        {
            int senderNumberOrd = reader.GetOrdinal("SenderNumber");
            int updatedAtOrd  = reader.GetOrdinal("UpdatedAt");
            int updatedByOrd  = reader.GetOrdinal("UpdatedBy_ID");

            return new clsPayment
            {
                PaymentID             = reader.GetInt32(reader.GetOrdinal("PaymentID")),
                PaymentType_ID        = reader.GetInt32(reader.GetOrdinal("PaymentType_ID")),
                PaymentDestination_ID = reader.GetInt32(reader.GetOrdinal("PaymentDestination_ID")),
                Appointment_ID        = reader.GetInt32(reader.GetOrdinal("Appointment_ID")),
                CreatedBy_ID          = reader.GetInt32(reader.GetOrdinal("CreatedBy_ID")),
                IsApproved            = reader.GetBoolean(reader.GetOrdinal("IsApproved")),
                SenderNumber          = reader.IsDBNull(senderNumberOrd)? null:  reader.GetString(senderNumberOrd),
                Amount                = reader.GetDecimal(reader.GetOrdinal("Amount")),
                CreatedAt             = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt             = reader.IsDBNull(updatedAtOrd) ? (DateTime?)null : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID          = reader.IsDBNull(updatedByOrd) ? (int?)null      : reader.GetInt32(updatedByOrd),
            };
        }

        private static clsPaymentType MapPaymentType(SqlDataReader reader)
        {
            return new clsPaymentType
            {
                PaymentTypeID   = reader.GetInt32(reader.GetOrdinal("PaymentTypeID")),
                PaymentTypeName = reader.GetString(reader.GetOrdinal("PaymentTypeName")),
            };
        }

        private static clsPaymentDestination MapPaymentDestination(SqlDataReader reader)
        {
            return new clsPaymentDestination
            {
                PaymentDestinationID   = reader.GetInt32(reader.GetOrdinal("PaymentDestinationID")),
                PaymentDestinationName = reader.GetString(reader.GetOrdinal("PaymentDestinationName")),
            };
        }
    }
}
