using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Model
{
    internal class Patients
    {
        public int PatientId { get;  set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string ContactNumber { get; set ; }
        public string Address { get; set; }

        public Patients()
        {

        }

        // Constructor
        public Patients(int patientId, string firstName, string lastName, DateTime dateOfBirth, char gender, string contactNumber, string address)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactNumber = contactNumber;
            Address = address;
        }

        public override string ToString()
        {
            return $"{PatientId} {FirstName} {LastName} {DateOfBirth} {Gender} {ContactNumber} {Address}";
        }
    }
}

