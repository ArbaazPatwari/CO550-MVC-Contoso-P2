using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_Contoso.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        
    }
}

