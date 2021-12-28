using StudentRegistration.Property;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StudentRegistration.Services.IRepository
{
    public interface IStuRegistration
    {
        List<City> GetCity(string StateId);
        List<State> GetState(string CountryId);
        List<TypeOfOrganization> GetTypeOfOrganizations();
        List<Country> GetCountries();
        bool AddRegistration(RegisterStudent Model,string otp);
        Login GetLogin(string Userid, string Password);
        bool VerifyOTP(string mobno, string otp);
        List<RegisterStudent> RegisterStudentList();
    }
}

