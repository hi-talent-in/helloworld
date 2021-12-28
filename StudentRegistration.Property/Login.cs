using System;
using System.Collections.Generic;
using System.Text;

namespace StudentRegistration.Property
{
    public class Login
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlock { get; set; }
         public bool RememberMe { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string IPAddress { get; set; }
        public bool IsLockOut { get; set; }
        
    }
}
