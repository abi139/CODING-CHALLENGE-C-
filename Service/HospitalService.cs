using CodingChallenge.Model;
using CodingChallenge.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Exceptions;
using System.ComponentModel.Design;

namespace CodingChallenge.Service
{
    internal class HospitalService : IHospitalService
    {
        public AppointmentRepository appointmentRespository;


        public HospitalService()
        {
            appointmentRespository = new AppointmentRepository();
        }

        public Appointments GetAppointmentById(int appointmentId)
        {
            try
            {
                Appointments appointment = appointmentRespository.GetAppointmentById(appointmentId);

                if (appointment != null)
                {
                    Console.WriteLine("Appointment Details:");
                    Console.WriteLine($"Appointment ID: {appointment.AppointmentId}");
                    Console.WriteLine($"Patient ID: {appointment.PatientId}");
                    Console.WriteLine($"Doctor ID: {appointment.DoctorId}");
                    Console.WriteLine($"Appointment Date: {appointment.AppointmentDate}");
                    Console.WriteLine($"Description: {appointment.Description}");
                }
                else
                {
                    Console.WriteLine("Appointment not found.");
                }

                return appointment;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting appointment ID: {ex.Message}");
                return null;
            }
        }


        public List<Appointments> GetAppointmentsForPatient(int patientId)
        {
            try
            {
                List<Appointments> appointments = appointmentRespository.GetAppointmentsForPatient(patientId);

               
                if (appointments.Count > 0)
                {
                    Console.WriteLine("\nAppointments for Patient:");
                    foreach (var appointment in appointments)
                    {
                        Console.WriteLine($"Appointment ID: {appointment.AppointmentId}");
                        Console.WriteLine($"Doctor ID: {appointment.DoctorId}");
                        Console.WriteLine($"Appointment Date: {appointment.AppointmentDate}");
                        Console.WriteLine($"Description: {appointment.Description}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    
                    Console.WriteLine("No appointments found for the patient.");
                }

                return appointments;
            }
            catch (PatientNotFoundException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Appointments>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Appointments>();
            }
        }


        public List<Appointments> GetAppointmentsForDoctor(int doctorId)
        {
            try
            {
                List<Appointments> appointments = appointmentRespository.GetAppointmentsForDoctor(doctorId);

                
                if (appointments.Count > 0)
                {
                    Console.WriteLine("\nAppointments for Doctor:");
                    foreach (var appointment in appointments)
                    {
                        Console.WriteLine($"Appointment ID: {appointment.AppointmentId}");
                        Console.WriteLine($"Patient ID: {appointment.PatientId}");
                        Console.WriteLine($"Appointment Date: {appointment.AppointmentDate}");
                        Console.WriteLine($"Description: {appointment.Description}");
                        Console.WriteLine();
                    }
                }
                else
                {
                   
                    Console.WriteLine("No appointments found for the doctor.");
                }

                return appointments;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Appointments>();
            }
        }



        public bool ScheduleAppointment(Appointments appointment)
        {
            try
            {
                bool result = appointmentRespository.ScheduleAppointment(appointment);
                if (result)
                {
                    Console.WriteLine("Appointment scheduled successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to schedule appointment.");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public bool UpdateAppointment(Appointments appointment)
        {
            try
            {
                bool result = appointmentRespository.UpdateAppointment(appointment);
                if (result)
                {
                    Console.WriteLine("Appointment updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update appointment.");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public bool CancelAppointment(int appointmentId)
        {
            try
            {
                bool result = appointmentRespository.CancelAppointment(appointmentId);
                if (result)
                {
                    Console.WriteLine("Appointment cancelled successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to cancel appointment.");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}

