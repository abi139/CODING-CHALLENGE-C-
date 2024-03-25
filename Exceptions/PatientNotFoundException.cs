using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Model;

namespace CodingChallenge.Exceptions
{
    internal class PatientNotFoundException:Exception
    {

        public PatientNotFoundException(string message) : base(message)
        {
        }

        public static bool PatientIDNotFound(int patientid)
        {
            List<Appointments> appointments = new List<Appointments>();
            foreach(Appointments item in appointments)
            {
                if(item.PatientId==patientid)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
