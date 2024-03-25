using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Model;
using CodingChallenge.Service;

namespace CodingChallenge.HospitalManagementApp
{
    internal class HospitalManagement
    {

        IHospitalService hospitalService = new HospitalService();
        public void MainMenu()
        {

            int choice = 0;
            do
            {
                Console.WriteLine("Hospital Management System");
                Console.WriteLine("1. Get Appointment by ID");
                Console.WriteLine("2. Get Appointments for Patient");
                Console.WriteLine("3. Get Appointments for Doctor");
                Console.WriteLine("4. Schedule Appointment");
                Console.WriteLine("5. Update Appointment");
                Console.WriteLine("6. Cancel Appointment");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");


                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Appointment ID: ");
                        int appointmentId = Convert.ToInt32(Console.ReadLine());
                        hospitalService.GetAppointmentById(appointmentId);
                        break;

                    case 2:
                        Console.Write("Enter Patient ID: ");
                        int patientId = Convert.ToInt32(Console.ReadLine());
                        hospitalService.GetAppointmentsForPatient(patientId);
                        break;


                    case 3:
                        Console.Write("Enter Doctor ID: ");
                        int doctorId = Convert.ToInt32(Console.ReadLine());
                        hospitalService.GetAppointmentsForDoctor(doctorId);
                        break;

                    case 4:

                        Console.Write("Enter Patient ID: ");
                        int patientIdForNewAppointment = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Doctor ID: ");
                        int doctorIdForNewAppointment = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Appointment Date (YYYY-MM-DD HH:MM): ");
                        DateTime appointmentDateForNewAppointment = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Description: ");
                        string descriptionForNewAppointment = Console.ReadLine();

                        Appointments newAppointment = new Appointments()
                        {
                            PatientId = patientIdForNewAppointment,
                            DoctorId = doctorIdForNewAppointment,
                            AppointmentDate = appointmentDateForNewAppointment,
                            Description = descriptionForNewAppointment
                        };

                        hospitalService.ScheduleAppointment(newAppointment);
                        break;

                    case 5:

                        Console.Write("Enter Appointment ID to update: ");
                        int appointmentToUpdateId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Patient ID: ");
                        int newPatientIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Doctor ID: ");
                        int newDoctorIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Appointment Date (YYYY-MM-DD HH:MM): ");
                        DateTime newAppointmentDateForUpdate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter New Description: ");
                        string newDescriptionForUpdate = Console.ReadLine();

                        Appointments updatedAppointment = new Appointments()
                        {

                            PatientId = newPatientIdForUpdate,
                            DoctorId = newDoctorIdForUpdate,
                            AppointmentDate = newAppointmentDateForUpdate,
                            Description = newDescriptionForUpdate
                        };

                        hospitalService.UpdateAppointment(updatedAppointment);
                        break;

                    case 6:

                        Console.Write("Enter Appointment ID to cancel: ");
                        int appointmentIdToCancel = Convert.ToInt32(Console.ReadLine());
                        hospitalService.CancelAppointment(appointmentIdToCancel);
                        break;

                    case 7:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 7);
        }
    }
}
