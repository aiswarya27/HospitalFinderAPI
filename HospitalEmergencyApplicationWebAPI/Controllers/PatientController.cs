using HospitalEmergencyApplicationWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HospitalEmergencyApplicationWebAPI.Controllers
{
    public class PatientController : ApiController
    {
        public string Post(Patient patient)
        {
            try
            {
                DataSet ds = new DataSet();
                string query= @"insert into patient(name) values('" + patient.Name+  @"')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HospitalConn"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    da.Fill(ds);
                }

                return "Added SuccessFully";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Failed to add";
            }
        }
    }
}
