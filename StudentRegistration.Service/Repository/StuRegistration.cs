using Microsoft.AspNetCore.Mvc.Rendering;
using StudentRegistration.Property;
using StudentRegistration.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;

namespace StudentRegistration.Services.Repository
{
    public class StuRegistration : IStuRegistration
    {
        string ConnectionString = "Data Source=192.168.1.206;Initial Catalog=APIDB; User Id=sa;Password=abc@123;";
        public bool VerifyOTP(string mobno, string otp)
        {
            try
            {
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("SP_VerifyOTP", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.Add("@Result", SqlDbType.BigInt, 0).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@Mobile", mobno).ToString();
                cmd.Parameters.AddWithValue("@OTP", otp).ToString();
                sqlconnection.Open();
                //cmd.ExecuteNonQuery();
                long ID = 0;// Convert.ToInt64(cmd.Parameters["@Result"].Value);
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                sqlconnection.Close();
                if (int.Parse(dt.Rows[0]["StudentId"].ToString()) > 0)
                {
                    string org = "Thanks Yoctel";
                    string _url = "http://newsms.yoctel.com/submitsms.jsp?user=Yoctel1&key=f32240e20cXX&mobile=+91#MOBILE#&message=#MESSAGE#&senderid=OTPYOC&accusage=1";
                    string Number = mobno;
                    string MessageOTP = "Your UserName : " + dt.Rows[0]["UserId"].ToString() + " and Pwd: " + dt.Rows[0]["Password"].ToString() + " for Login with " + org + "";
                    string URL = _url.Replace("#MOBILE#", Number).Replace("#MESSAGE#", MessageOTP);
                    try
                    {
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
                        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                        StreamReader sr = new StreamReader(resp.GetResponseStream());
                        string results = sr.ReadToEnd();
                        sr.Close();

                    }
                    catch (Exception ex)
                    {
                        return false;
                    }

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
        public bool AddRegistration(RegisterStudent Model, string otp)
        {
            try
            {
                SqlConnection sqlconnection = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("SP_RegistrationStudent", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StudentId", SqlDbType.BigInt, 0, "StudentId").Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@Name", Model.Name);
                cmd.Parameters.AddWithValue("@Mobile", Model.Mobile);
                cmd.Parameters.AddWithValue("@EmailId", Model.EmailId);
                cmd.Parameters.AddWithValue("@OrganizationName", Model.OrganizationName);
                cmd.Parameters.AddWithValue("@Address", Model.Address);
                cmd.Parameters.AddWithValue("@Country", Model.Country);
                cmd.Parameters.AddWithValue("@State", Model.State);
                cmd.Parameters.AddWithValue("@City", Model.City);
                cmd.Parameters.AddWithValue("@Pin", Model.Pin);
                cmd.Parameters.AddWithValue("@TypeOfOrganization", Model.TypeOfOrganization);
                cmd.Parameters.AddWithValue("@Other", Model.Other);
                cmd.Parameters.AddWithValue("@OwnerName", Model.OwnerName);
                cmd.Parameters.AddWithValue("@OwnerContactNo", Model.OwnerContactNo);
                cmd.Parameters.AddWithValue("@OwnerEmailId", Model.OwnerEmailId);
                cmd.Parameters.AddWithValue("@GSTNO", Model.GSTNO);
                cmd.Parameters.AddWithValue("@OTP", otp);
                sqlconnection.Open();
                cmd.ExecuteNonQuery();
                long ID = Convert.ToInt64(cmd.Parameters["@StudentId"].Value);
                // ID=(int)cmd.Parameters["@StudentId"].Value;
                sqlconnection.Close();
                if (ID >= 0)
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
        public List<TypeOfOrganization> GetTypeOfOrganizations()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SP_GetTypeOfOrganization", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                List<TypeOfOrganization> lst = new List<TypeOfOrganization>();
                foreach (DataRow dr in dt.Rows)
                {
                    TypeOfOrganization organization = new TypeOfOrganization();
                    organization.OrganizationId = Convert.ToInt64(dr["OrganizationId"]);
                    organization.OrganizationType = dr["OrganizationType"].ToString();
                    lst.Add(organization);
                }
                return lst;
            }
            else
            {
                return null;
            }
        }
        public List<Country> GetCountries()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SP_GetCountry", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                List<Country> lst = new List<Country>();
                foreach (DataRow dr in dt.Rows)
                {
                    Country country = new Country();
                    country.CountryId = Convert.ToInt64(dr["CountryId"]);
                    country.CountryName = dr["CountryName"].ToString();
                    lst.Add(country);
                }
                return lst;
            }
            else
            {
                return null;
            }
        }
        //Get all State
        public List<State> GetState(string CountryId)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("SP_GetState", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@CountryId", CountryId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    List<State> lst = new List<State>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        State state = new State();
                        state.StateId = Convert.ToInt64(dr["StateId"]);
                        state.StateName = dr["StateName"].ToString();
                        lst.Add(state);
                    }
                    return lst;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        ////Get all city
        public List<City> GetCity(string StateId)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("SP_GetCity", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@StateId", StateId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    List<City> lst = new List<City>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        City city = new City();
                        city.CityId = Convert.ToInt64(dr["CityId"]);
                        city.CityName = dr["CityName"].ToString();
                        lst.Add(city);
                    }
                    return lst;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //student login 
        public Login GetLogin(string Userid, string Password)
        {
            //checking credential into database
            try
            {
                if (!string.IsNullOrEmpty(Userid) && !string.IsNullOrEmpty(Password))
                {
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_Getlogindetail", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@UserId", Userid);
                    da.SelectCommand.Parameters.AddWithValue("@Password", Password);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Login login = new Login();
                        login.UserId = dt.Rows[0]["UserId"].ToString();
                        login.Password = dt.Rows[0]["Password"].ToString();
                        login.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                        return login;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<RegisterStudent> RegisterStudentList()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            List<RegisterStudent> lststd = new List<RegisterStudent>();
            SqlCommand cmd = new SqlCommand("GetAllStudentRegister", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                RegisterStudent std = new RegisterStudent();
                std.Name = sdr["Name"].ToString();
                std.Mobile = sdr["Mobile"].ToString();
                std.EmailId = sdr["EmailId"].ToString();
                std.OrganizationName = sdr["OrganizationName"].ToString();
                std.Address = sdr["Address"].ToString();
                std.Country = sdr["Country"].ToString();
                std.State = sdr["State"].ToString();
                std.City = sdr["City"].ToString();
                std.Pin = sdr["Pin"].ToString();
                std.TypeOfOrganization = sdr["TypeOfOrganization"].ToString();
                std.Other = sdr["Other"].ToString();
                std.OwnerName = sdr["OwnerName"].ToString();
                std.OwnerContactNo = sdr["OwnerContactNo"].ToString();
                std.OwnerEmailId = sdr["OwnerEmailId"].ToString();
                std.GSTNO = sdr["GSTNO"].ToString();
                lststd.Add(std);
            }
            con.Close();
            return lststd;
        }
    }
}


