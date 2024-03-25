using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Model;
using CodingChallenge.Repository;

namespace CodingChallenge.Service
{
    internal interface IHospitalService
    {
        Appointments GetAppointmentById(int appointmentId);
        List<Appointments> GetAppointmentsForPatient(int patientId);
        List<Appointments> GetAppointmentsForDoctor(int doctorId);
        bool ScheduleAppointment(Appointments appointment);
        bool UpdateAppointment(Appointments appointment);
        bool CancelAppointment(int appointmentId);
    }
}
