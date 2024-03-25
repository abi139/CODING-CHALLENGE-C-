using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using CodingChallenge.Model;

namespace CodingChallenge.Exceptions
{
    internal class DoctorNotFoundExceptions:Exception
    {
        public DoctorNotFoundExceptions(string message) : base(message)
        {

        }
        public static bool DoctorIDNotFound(int doctorid)
        {
            List<Appointments> appointments = new List<Appointments>();
            foreach(Appointments item in appointments)
            {
                if(item.DoctorId==doctorid)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
