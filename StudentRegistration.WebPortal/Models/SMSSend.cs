// Install the C# / .NET helper library from twilio.com/docs/csharp/install
using System;
using System.IO;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SMSSENDER
{
    public static class SMSSend
    {
        public static string SENDSMS(string MOBNO, string Message)
        {
            string _url = "http://newsms.yoctel.com/submitsms.jsp?user=Yoctel1&key=f32240e20cXX&mobile=+91#MOBILE#&message=#MESSAGE#&senderid=OTPYOC&accusage=1";
            string Number = MOBNO;
            string MessageOTP = "Your OTP Code is - " + Message + "  Thanks OTP";
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

            }
            return MessageOTP;
        }
    }
}
