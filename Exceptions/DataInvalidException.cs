using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CodingChallenge.Model;

namespace CodingChallenge.Exceptions
{
    internal class DataInvalidException:Exception
    {
        public DataInvalidException(string message): base(message) {
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {

            string pattern = @"^\d{10}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(phoneNumber);
        }
    }
}
