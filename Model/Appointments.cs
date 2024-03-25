using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Model
{
    internal class Appointments
    {
        public int AppointmentId { get; private set; } // Automatically generated, hence private setter
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
        public Appointments()
        {

        }

        // Constructor
        public Appointments(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, string description)
        {
            AppointmentId = appointmentId;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
            Description = description;
        }

        public override string ToString()
        {
            return $"{AppointmentId} {PatientId} {DoctorId} {AppointmentDate} {Description}";
        }
    }
}

