using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Timeprj
    {
        public bool Validate(Datatable dataTable)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=IN-5CG0251NSB;AttachDbFilename=|DataDirectory|Timesheet.mdf;Initial Catalog=aspnet-TimesheetPrj-20200930010642;
                Integrated Security=True";
                SqlCommand cmd = new SqlCommand("select * from Signins where username=@username and password=@password", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", dataTable.username);
                cmd.Parameters.AddWithValue("@password", dataTable.password);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool UserExistorNot(Datatable credentials)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=IN-5CG0251NSB;AttachDbFilename=|DataDirectory|Timesheet.mdf;Initial Catalog=aspnet-TimesheetPrj-20200930010642;
                Integrated Security=True";
                SqlCommand cmd = new SqlCommand("select * from Signins where username=@username",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", credentials.username);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}
