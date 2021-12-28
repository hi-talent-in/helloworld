using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration.WebPortal.Models
{
    public class OPTViewModel
    {
       
        public int StudendId { get; set; }
        [Required(ErrorMessage = "Enter Correct OTP")]
        public int OTP { get; set; }
    }
}
