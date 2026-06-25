using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DentalClinic_CoreTier;
using DentalClinic_CoreTier.Interfaces;
using DentalClinic_CoreTier.Interfaces.RepositoryInterfaces;
using DentalClinic_CoreTier.Models;
using DentalClinic_CoreTier.ViewModels;

namespace DentalClinic_DataTier.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AppointmentRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAppointmentAsync(clsAppointment appointment)
        {
            try
            {
                int returnedAppointmentID = -1;
                const string query = @"
                    INSERT INTO Appointments
                        (Problem_ID, Doctor_ID, AppointmentDate, StartTime, EndTime, Status, Cause, Payment_ID, CreatedAt)
                    VALUES
                        (@Problem_ID, @Doctor_ID, @AppointmentDate, @StartTime, @EndTime, @Status, @Cause, @Payment_ID, @CreatedAt);
                    SELECT SCOPE_IDENTITY();";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Problem_ID", appointment.Problem_ID);
                    cmd.Parameters.AddWithValue("@Doctor_ID", appointment.Doctor_ID);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@StartTime", appointment.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", appointment.EndTime);
                    cmd.Parameters.AddWithValue("@Status", appointment.Status.ToString());
                    cmd.Parameters.AddWithValue("@Cause", (object)appointment.Cause ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Payment_ID", (object)appointment.Payment_ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", appointment.CreatedAt);

                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        returnedAppointmentID = insertedID;
                }
                return returnedAppointmentID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<clsAppointment> GetAppointmentByIdAsync(int appointmentId)
        {
            try
            {
                const string query = @"
                    SELECT AppointmentID, Problem_ID, Doctor_ID, AppointmentDate, StartTime, EndTime,
                           Status, Cause, Payment_ID, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM Appointments
                    WHERE AppointmentID = @AppointmentID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                            return MapAppointment(reader);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<clsAppointment>> GetAppointmentsByDoctorAndDateAsync(int doctorId, DateTime date)
        {
            try
            {
                const string query = @"
                    SELECT AppointmentID, Problem_ID, Doctor_ID, AppointmentDate, StartTime, EndTime,
                           Status, Cause, Payment_ID, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM Appointments
                    WHERE Doctor_ID = @DoctorID
                      AND CAST(AppointmentDate AS DATE) = CAST(@Date AS DATE)";

                var list = new List<clsAppointment>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                    cmd.Parameters.AddWithValue("@Date", date.Date);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapAppointment(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<clsAppointment>> GetAppointmentsByProblemIdAsync(int problemId)
        {
            try
            {
                const string query = @"
                    SELECT AppointmentID, Problem_ID, Doctor_ID, AppointmentDate, StartTime, EndTime,
                           Status, Cause, Payment_ID, CreatedAt, UpdatedAt, UpdatedBy_ID
                    FROM Appointments
                    WHERE Problem_ID = @ProblemID";

                var list = new List<clsAppointment>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProblemID", problemId);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapAppointment(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<clsAppointmentsDetails>> GetAppointmentsByDateAsync(DateTime fromDate, DateTime toDate)
        {
            try
            {
                const string query = @"
                    SELECT AppointmentID,Problem_ID, Doctor_ID,AppointmentDate, StartTime, EndTime,
                    Status, Cause, Payment_ID, CreatedAt, UpdatedAt,UpdatedBy_ID,
                    PatientID,PatientFullName ,PhoneNumber,
                    DoctorFullName,MedicalFileID
                    FROM vw_AppointmentsDetails
                    WHERE CAST(AppointmentDate AS DATE) BETWEEN CAST(@FromDate AS DATE) AND CAST(@ToDate AS DATE)";

                var list = new List<clsAppointmentsDetails>();
                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapAppointmentDetails(reader));
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UpdateAppointmentAsync(clsAppointment appointment)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE Appointments
                    SET Problem_ID      = @Problem_ID,
                        Doctor_ID       = @Doctor_ID,
                        AppointmentDate = @AppointmentDate,
                        StartTime       = @StartTime,
                        EndTime         = @EndTime,
                        Status          = @Status,
                        Cause           = @Cause,
                        Payment_ID      = @Payment_ID,
                        UpdatedAt       = @UpdatedAt,
                        UpdatedBy_ID    = @UpdatedBy_ID
                    WHERE AppointmentID = @AppointmentID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", appointment.AppointmentID);
                    cmd.Parameters.AddWithValue("@Problem_ID", appointment.Problem_ID);
                    cmd.Parameters.AddWithValue("@Doctor_ID", appointment.Doctor_ID);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@StartTime", appointment.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", appointment.EndTime);
                    cmd.Parameters.AddWithValue("@Status", appointment.Status.ToString());
                    cmd.Parameters.AddWithValue("@Cause", (object)appointment.Cause ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Payment_ID", (object)appointment.Payment_ID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedAt", (object)appointment.UpdatedAt ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedBy_ID", (object)appointment.UpdatedBy_ID ?? DBNull.Value);

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

        public async Task<bool> UpdateAppointmentStatusAsync(int appointmentId, myEnums.enAppointmentStatus status, int updatedById)
        {
            try
            {
                bool isUpdated = false;
                const string query = @"
                    UPDATE Appointments
                    SET Status       = @Status,
                        UpdatedAt    = SYSDATETIME(),
                        UpdatedBy_ID = @UpdatedBy_ID
                    WHERE AppointmentID = @AppointmentID";

                using (var conn = _connectionFactory.CreateConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
                    cmd.Parameters.AddWithValue("@Status", status.ToString());
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

        private static clsAppointment MapAppointment(SqlDataReader reader)
        {
            int causeOrd = reader.GetOrdinal("Cause");
            int paymentOrd = reader.GetOrdinal("Payment_ID");
            int updatedAtOrd = reader.GetOrdinal("UpdatedAt");
            int updatedByOrd = reader.GetOrdinal("UpdatedBy_ID");

            return new clsAppointment
            {
                AppointmentID = reader.GetInt32(reader.GetOrdinal("AppointmentID")),
                Problem_ID = reader.GetInt32(reader.GetOrdinal("Problem_ID")),
                Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID")),
                AppointmentDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                StartTime = (TimeSpan)reader.GetValue(reader.GetOrdinal("StartTime")),
                EndTime = (TimeSpan)reader.GetValue(reader.GetOrdinal("EndTime")),
                Status = (myEnums.enAppointmentStatus)Enum.Parse(typeof(myEnums.enAppointmentStatus), reader.GetString(reader.GetOrdinal("Status"))),
                Cause = reader.IsDBNull(causeOrd) ? null : reader.GetString(causeOrd),
                Payment_ID = reader.IsDBNull(paymentOrd) ? (int?)null : reader.GetInt32(paymentOrd),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt = reader.IsDBNull(updatedAtOrd) ? (DateTime?)null : reader.GetDateTime(updatedAtOrd),
                UpdatedBy_ID = reader.IsDBNull(updatedByOrd) ? (int?)null : reader.GetInt32(updatedByOrd),
            };
        }
        private static clsAppointmentsDetails MapAppointmentDetails(SqlDataReader reader)
        {
            int phoneOrd = reader.GetOrdinal("PhoneNumber");
            clsAppointmentsDetails AppointmentsDetails = new clsAppointmentsDetails
            {
                MedicalFileID = reader.GetInt32(reader.GetOrdinal("MedicalFileID")),
                PatientID = reader.GetInt32(reader.GetOrdinal("PatientID")),
                PatientFullName = reader.GetString(reader.GetOrdinal("PatientFullName")),
                PatientPhone = reader.IsDBNull(phoneOrd) ? null : reader.GetString(phoneOrd),
                DoctorFullName = reader.GetString(reader.GetOrdinal("DoctorFullName")),
            };
            AppointmentsDetails.Appointment = MapAppointment(reader);
            
            return AppointmentsDetails;

        }
    }
}
