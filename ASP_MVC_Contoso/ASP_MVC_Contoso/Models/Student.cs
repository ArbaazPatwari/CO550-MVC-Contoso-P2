using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_MVC_Contoso.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public ICollection<Enrollment> Enrollments { get; set; }
        
    }
}

