using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CodingChallenge.Utility;

namespace CodingChallenge.Repository
{
    internal class PatientRepository
    {
        SqlConnection sql = null;
        SqlCommand cmd = null;

        public PatientRepository()
        {
            sql = new SqlConnection(DatabaseUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

    }
}
