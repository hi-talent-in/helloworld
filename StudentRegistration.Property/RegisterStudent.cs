using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Property
{
    public class RegisterStudent
    {
        [Key]
        public long StudentID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string TypeOfOrganization { get; set; }
        public string Other { get; set; }
        public string OwnerName { get; set; }
        public string OwnerContactNo { get; set; }
        public string OwnerEmailId { get; set; }
        public string GSTNO { get; set; }

    }
}
