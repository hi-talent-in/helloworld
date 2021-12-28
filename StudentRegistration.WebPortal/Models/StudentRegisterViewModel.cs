using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration.WebPortal.Models
{
    public class StudentRegisterViewModel
    {
        [Key]
        public long StudentID { get; set; }
        [Required(ErrorMessage ="Enter your Name")]
        [Display(Name ="Name:")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter your MobileNumber")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="MobileNumber:")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Enter your EmailId")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EmailId:")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Enter your correct EmailId")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Enter your OrganizationName")]
        [Display(Name= "OrganizationName:")]
        public string OrganizationName { get; set; }
        [Required(ErrorMessage ="Enter your Address")]
        [Display(Name ="Address:")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Enter your Country")]
        [Display(Name ="Country:")]
        public string Country { get; set; }
        [Required(ErrorMessage ="Enter your State")]
        [Display(Name="State:")]
        public string State { get; set; }
        [Required(ErrorMessage ="Enter your City")]
        [Display(Name="City:")]
        public string City { get; set; }
        [Required(ErrorMessage ="Enter your PinCode")]
        [Display(Name="PinCode:")]
        public string Pin { get; set; }
        public string TypeOfOrganization { get; set; }
        public string Other { get; set; }
        public string OwnerName { get; set; }
        public string OwnerContactNo { get; set; }
        public string OwnerEmailId { get; set; }
        public string GSTNO { get; set; }
    }
}

