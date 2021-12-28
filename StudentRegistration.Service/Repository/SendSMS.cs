using StudentRegistration.Property;
using StudentRegistration.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace StudentRegistration.Services.Repository
{
    public class SendSMS : ISendSMS
    {
        string ConnectionString = "Data Source=192.168.1.206;Initial Catalog=APIDB; User Id=sa;Password=abc@123;";
        public bool GetSMS(SMS sms)
        {
            //checking credential into database
            try
            {
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@To", sms.To);
                cmd.Parameters.AddWithValue("@From", sms.From);
                cmd.Parameters.AddWithValue("@Message", sms.Message);
                sqlconnection.Open();
                int n = cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if (n >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
