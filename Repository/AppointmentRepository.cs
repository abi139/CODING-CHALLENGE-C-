using CodingChallenge.Exceptions;
using CodingChallenge.Model;
using CodingChallenge.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Repository
{
    internal class AppointmentRepository
    {
        SqlConnection sql = null;
        SqlCommand cmd = null;

        public AppointmentRepository()
        {
            sql = new SqlConnection(DatabaseUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public Appointments GetAppointmentById(int appointmentId)
        {
            Appointments appointment = null;
            using (SqlConnection sql = new SqlConnection(DatabaseUtility.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand())
            {
                sql.Open();
                cmd.Connection = sql;
                cmd.CommandText = "SELECT * FROM Appointment WHERE appointmentId = @appointmentId";
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    appointment = new Appointments(
                        (int)(reader["appointmentId"]),
                        Convert.ToInt32(reader["patientId"]),
                        Convert.ToInt32(reader["doctorId"]),
                        (DateTime)(reader["appointmentDate"]),
                        reader["descriptionn"].ToString());
                }
            }
            return appointment;
        }

        public List<Appointments> GetAppointmentsForPatient(int patientId)
        {
            List<Appointments> appointments = new List<Appointments>();
            using (SqlConnection sql = new SqlConnection(DatabaseUtility.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand())
            {
                sql.Open();
                cmd.Connection = sql;
                cmd.CommandText = "SELECT * FROM Appointment WHERE patientId = @patientId";
                cmd.Parameters.AddWithValue("@patientId", patientId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    appointments.Add(new Appointments(
                        Convert.ToInt32(reader["appointmentId"]),
                        Convert.ToInt32(reader["patientId"]),
                        Convert.ToInt32(reader["doctorId"]),
                        Convert.ToDateTime(reader["appointmentDate"]),
                        reader["descriptionn"].ToString()));
                }
            }
            return appointments;
        }

        public List<Appointments> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointments> appointments = new List<Appointments>();
            using (SqlConnection sql = new SqlConnection(DatabaseUtility.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand())
            {
                sql.Open();
                cmd.Connection = sql;
                cmd.CommandText = "SELECT * FROM Appointment WHERE doctorId = @doctorId";
                cmd.Parameters.AddWithValue("@doctorId", doctorId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    appointments.Add(new Appointments(
                        Convert.ToInt32(reader["appointmentId"]),
                        Convert.ToInt32(reader["patientId"]),
                        Convert.ToInt32(reader["doctorId"]),
                        Convert.ToDateTime(reader["appointmentDate"]),
                        reader["descriptionn"].ToString()));
                }
            }
            return appointments;
        }

        public bool ScheduleAppointment(Appointments appointment)
        {
            using (SqlConnection sql = new SqlConnection(DatabaseUtility.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand())
            {
                sql.Open();
                cmd.Connection = sql;
                cmd.CommandText = "INSERT INTO Appointment (patientId, doctorId, appointmentDate, descriptionn) VALUES (@patientId, @doctorId, @appointmentDate, @description)";
                cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
                cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@description", appointment.Description);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool UpdateAppointment(Appointments appointment)
        {
            using (SqlConnection sql = new SqlConnection(DatabaseUtility.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand())
            {
                sql.Open();
                cmd.Connection = sql;
                cmd.CommandText = "UPDATE Appointment SET patientId = @patientId, doctorId = @doctorId, appointmentDate = @appointmentDate, descriptionn = @description WHERE appointmentId = @appointmentId";
                cmd.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);
                cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
                cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@description", appointment.Description);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CancelAppointment(int appointmentId)
        {
            using (SqlConnection sql = new SqlConnection(DatabaseUtility.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand())
            {
                sql.Open();
                cmd.Connection = sql;
                cmd.CommandText = "DELETE FROM Appointment WHERE appointmentId = @appointmentId";
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}

