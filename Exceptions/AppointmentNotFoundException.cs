using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Model;

namespace CodingChallenge.Exceptions
{
    internal class AppointmentNotFoundException:Exception
    {
        public AppointmentNotFoundException (string message):base(message) {
        }

        public static bool AppointmentIDNotFound(int appointmentID)
        {
            List<Appointments> appointments = new List<Appointments>();
            foreach(Appointments item in appointments)
            {
                if(item.AppointmentId==appointmentID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
