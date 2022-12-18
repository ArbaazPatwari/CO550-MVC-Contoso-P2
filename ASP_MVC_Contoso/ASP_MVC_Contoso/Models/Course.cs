using ASP_MVC_Contoso.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_MVC_Contoso.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        // navigation properties
        public Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}