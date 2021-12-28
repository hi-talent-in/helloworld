using Microsoft.EntityFrameworkCore;
using StudentRegistration.Property;
using System;

namespace StudentRegistration.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        DbSet<RegisterStudent> registerStudents { get; set; }
    }
}
