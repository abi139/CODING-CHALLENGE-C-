using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Model
{
    internal class Doctors
    {
        public int DoctorId { get; private set; } // Automatically generated, hence private setter
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }

        public Doctors()
        {

        }

        // Constructor
        public Doctors(int doctorId, string firstName, string lastName, string specialization, string contactNumber)
        {
            DoctorId = doctorId;
            FirstName = firstName;
            LastName = lastName;
            Specialization = specialization;
            ContactNumber = contactNumber;
        }

        public override string ToString()
        {
            return $"{DoctorId} {FirstName} {LastName} {Specialization} {ContactNumber}";
        }
    }
}

